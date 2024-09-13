using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.DTOs
{
    public class CheckoutViewModel
    {
        public int StoreId { get; set; }  // The ID of the store for the current checkout
        public ShippingAddressDto ShippingAddress { get; set; }  // The shipping address details
        public List<CartItemDto> Items { get; set; }  // The list of items in the cart for this checkout

        // Optional: You can add more properties here if needed, such as:
        //public decimal TotalAmount
        //{
        //    get
        //    {
        //        return Items?.Sum(item => item.Price * item.Quantity) ?? 0;
        //    }
        //}
    }
}
