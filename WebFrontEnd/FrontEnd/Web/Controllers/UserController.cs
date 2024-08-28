using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.ServicesInterface;
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
                if (userCheck == null)
                {
                    ViewBag.Error = "Wrong username or password";
                    return View();
                }

                if (userCheck != null)
                {
                    if (userCheck.Status == 0)
                    {
                        ViewBag.Error = "This account was blocked";
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

                    if (!userCheck.IsEmailVerified)
                    {
                        _userService.SendVerificationEmail(userCheck);
                        return Json(new { success = false, message = "Your email haven't been verified yet, please check your email and verify it." });
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
        public async Task<IActionResult> SignUp(UserDto userDto)
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

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                ViewBag.Message = "Do not have this account in database";
                return View();
            }
            await _userService.ForgotPassword(email);
            ViewBag.Message = "Sent email success";
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token)
        {
            var model = new ResetPasswordDto { Token = token };
            return View(model);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            try
            {
                await _userService.ResetPassword(model);
                ViewBag.Message = "Your password has been successfully reset.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "You can not change the password, An error occurred while resetting your password.";
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return View(model);
        }

        public async Task<IActionResult> VerifyEmail(string token)
        {
            try
            {
                bool isVerified = await _userService.VerifyEmail(token);
                if (isVerified)
                {
                    ViewBag.Message = "Email verified successfully";
                }
                else
                {
                    ViewBag.Message = "Email verification failed";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "An error occurred while verifying your email.";
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return View();
        }

        public IActionResult VerifyEmail()
        {
            return View("VerifyEmail");
        }

        public async Task<IActionResult> ResendVerificationEmail()
        {
            // Implement the logic to resend the verification email
            var email = HttpContext.Session.GetString("userEmail"); // Assuming the email is stored in session
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "Email is not available.";
                return View("VerifyEmail");
            }

            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                ViewBag.Error = "User not found.";
                return View("VerifyEmail");
            }

            //await _userService.SendVerificationEmail(user);
            ViewBag.Message = "Verification email has been sent.";
            return View("VerifyEmail");
        }
    }
}
