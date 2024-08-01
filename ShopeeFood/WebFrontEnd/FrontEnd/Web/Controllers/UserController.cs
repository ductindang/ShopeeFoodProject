using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.Services.Contrast;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsers();
            return View(users);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserDto user)
        {
            var email = user.Email;
            var password = user.Password;
            var userCheck = _userService.GetUserByEmailPassword(email, password);

            try
            {
                if(userCheck == null)
                {
                    ViewBag.Error = "Wrong username or password";
                    return View();
                }

                if (userCheck != null)
                {
                    if (userCheck.Status == 0)
                    {
                        ViewBag.Error = "Nguoi dung nay da bi khoa tai khoan";
                        return View();
                    }
                    ViewBag.Error = "";
                    var userCheckJson = JsonConvert.SerializeObject(userCheck);
                    HttpContext.Session.SetString("userCheck", userCheckJson);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckLogin(string Email, string Password)
        {
            string email = Email;
            string password = Password;
            
            try
            {
                var userCheck = await _userService.GetUserByEmailPassword(email, password);
                if (userCheck == null)
                {
                    return Json(new { success = false, message = "Invalid email or password." });
                }

                if (userCheck != null)
                {
                    if (userCheck.Status == 0)
                    {
                        return Json(new { success = false, message = "This account has been locked." });
                    }
                    var userCheckJson = JsonConvert.SerializeObject(userCheck);
                    HttpContext.Session.SetString("userCheck", userCheckJson);
                    return Json(new { success = true, redirectUrl = Url.Action("Index") });
                }
                return Json(new { success = false, message = "An unknown error occurred." });
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                return Json(new { success = false, message = "An error occurred while processing your request. Please try again." });
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userCheck");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserDto userDto )
        {
            userDto.CreatedAt = DateTime.UtcNow.AddHours(7);
            userDto.UpdatedAt = DateTime.UtcNow.AddHours(7);

            try
            {
                var user = await _userService.InsertUser(userDto);
                if (user == null)
                {
                    ViewBag.Error = "Unable to sign up the user.";
                    return View();
                }

                ViewBag.Error = "";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                ViewBag.Error = "An error occurred while processing your request. Please try again.";
                return View();
            }
        }

        public async Task<IActionResult> CheckEmailExist(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            return Json(user);
        }

        


    }
}
