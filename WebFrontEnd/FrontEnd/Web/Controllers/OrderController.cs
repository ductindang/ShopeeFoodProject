using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.ServicesInterface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUserAddressService _userAddressService;
        private readonly IOrderService _orderService;
        private readonly IStoreService _storeService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IProductService _productService;

        public OrderController(IUserAddressService userAddressService, 
            IOrderService orderService, 
            IStoreService storeService,
            IOrderDetailService orderDetailService,
            IProductService productService)
        {
            _userAddressService = userAddressService;
            _orderService = orderService;
            _storeService = storeService;
            _orderDetailService = orderDetailService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(int storeId, ShippingAddressDto shippingAddress, List<CartItemDto> items)
        {
            

            var viewModel = new CheckoutViewModel
            {
                StoreId = storeId,
                ShippingAddress = shippingAddress,
                Items = items
            };

            // Return the PartialView with the populated data
            return PartialView("CheckOut", viewModel);
        }

        public async Task<IActionResult> OrderInfo()
        {
            // Get user data from session
            var userCheckJson = HttpContext.Session.GetString("userCheck");
            if (string.IsNullOrEmpty(userCheckJson))
            {
                return RedirectToAction("Login", "User"); // Redirect if session is missing
            }

            var user = JsonConvert.DeserializeObject<UserDto>(userCheckJson);

            // Fetch user addresses
            var userAddresses = await _userAddressService.GetAllUserAddressesByUser(user.Id) ?? new List<UserAddressDto>();

            // Fetch address details in parallel
            var userAddressDetailsTasks = userAddresses.Select(address => _userAddressService.GetUserAddressDetail(address.Id));
            var userAddressDetailsArray = await Task.WhenAll(userAddressDetailsTasks);

            // Filter out nulls and convert to a list
            var userAddressDetails = userAddressDetailsArray.Where(detail => detail != null).ToList();

            // Return the partial view
            return PartialView("OrderInfo", userAddressDetails);
        }


        public IActionResult AddAddress()
        {
            return PartialView("AddAddress");
        }

        [HttpPost]
        public async Task<IActionResult> AddAddressFromForm(UserAddressDto userAddress)
        {
            var addUserAddress = await _userAddressService.InsertUserAddress(userAddress);
            if (addUserAddress != null)
            {
                return RedirectToAction("EditAccount", "User");
            }
            return RedirectToAction("EditAccount", "User");
        }

        [HttpPost]
        public async Task<IActionResult> Order(int storeId, int addressId, List<CartItemDto> items)
        {
            // Validate if the addressId and cart are valid
            if (addressId <= 0 || items == null || !items.Any())
            {
                return BadRequest("Invalid order data.");
            }

            // Example logic: Get the user's address from the database
            var address = await _userAddressService.GetUserAddressDetail(addressId);
            if (address == null)
            {
                return NotFound("Address not found.");
            }

            var currentUserJson = HttpContext.Session.GetString("userCheck");
            var currentUser = JsonConvert.DeserializeObject<UserDto>(currentUserJson);


            var storeAddressesInProvinceJson = HttpContext.Session.GetString("storeAddressesInProvince");
            var storeAddressesInProvince = JsonConvert.DeserializeObject<IEnumerable<StoreAddressDto>>(storeAddressesInProvinceJson);

            var storeDetail = new StoreDetailDto();

            foreach (var stInPro in storeAddressesInProvince)
            {
                var store = await _storeService.GetStoreWithDetailAddress(stInPro.Id, storeId, stInPro.WardId);
                if (store != null)
                {
                    store.StoreId = storeId;
                    storeDetail = store;
                }
            }

            // Process the cart and place the order
            var newOrder = new OrderDto
            {
                UserId = currentUser.Id,
                PhoneNumber = address.PhoneNumber,
                AddressId = addressId,
                RecipientName = address.NameReminiscent,
                StoreName = storeDetail.StoreName,
                StoreAddress = $"{storeDetail.StreetName}, {storeDetail.WardName}, {storeDetail.DistrictName}, {storeDetail.ProvinceName}",
                Note = "Leave the package at the front door",
                OrderDate = DateTime.Now,
                Status = OrderStatus.Pending,
                TotalMoney = (double)items.Sum(item => item.Price * item.Quantity)
            };

            // Save the order to the database (assuming _orderService is your service for handling orders)
            var addOrder = await _orderService.InsertOrder(newOrder);

            foreach(var item in items)
            {
                var orderDetail = new BaseOrderDetailDto
                {
                    OrderId = addOrder.Id,
                    ProductName = item.Name,
                    Price = (double)item.Price,
                    ProductImage = item.Image,
                    Amount = item.Quantity,
                    TotalMoney = (double)item.Price * item.Quantity,
                };

                _orderDetailService.InsertOrderDetail(orderDetail);
            }

            // Return success message
            return Ok(new { message = "Order placed successfully!" });
        }

        public async Task<IActionResult> OrderHistory()
        {
            // Get user data from session
            var userCheckJson = HttpContext.Session.GetString("userCheck");
            if (string.IsNullOrEmpty(userCheckJson))
            {
                return RedirectToAction("Login", "User"); // Redirect if session is missing
            }

            var user = JsonConvert.DeserializeObject<UserDto>(userCheckJson);

            var orders = await _orderService.GetOrdersByUserId(user.Id);

            // Sort orders by OrderDate in descending order
            var sortedOrders = orders.OrderByDescending(o => o.OrderDate).ToList();

            return View(sortedOrders);
        }


        public async Task<IActionResult> Details(int orderId)
        {
            var orderDetails = await _orderDetailService.GetOrderDetailsByOrder(orderId);


            //var productDetails = new List<ProductDetailDto>();
            //foreach (var item in orderDetails)
            //{
            //    var productDetail = await _productService.GetProductWithDetailAddress(item.ProductId);
            //    if(productDetail != null)
            //    {
            //        productDetails.Add(productDetail);
            //    }
            //}
            //var productDetailInOrderJson = JsonConvert.SerializeObject(productDetails);
            //HttpContext.Session.SetString("productsInOrder", productDetailInOrderJson != null ? JsonConvert.SerializeObject(productDetails) : string.Empty);


            return View(orderDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Search(int status, DateTime? fromDate, DateTime? toDate)
        {
            // Get all orders from the service
            var orders = await _orderService.GetAllOrders();

            // Filter by status if not 0 (0 is for 'All' statuses)
            if (status != -1)
            {
                orders = orders.Where(o => (int)o.Status == status).ToList(); // Using enum value comparison
            }

            // Filter by 'fromDate' if provided
            if (fromDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate.Date >= fromDate.Value.Date).ToList();
            }

            // Filter by 'toDate' if provided
            if (toDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate.Date <= toDate.Value.Date).ToList();
            }

            // You can optionally add pagination or sorting logic here, depending on your needs

            // Return the filtered result as a PartialView
            return PartialView("_OrderTableRows", orders);
        }



    }
}
