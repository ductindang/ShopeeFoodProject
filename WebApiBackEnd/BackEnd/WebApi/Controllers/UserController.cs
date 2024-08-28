using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.ServicesInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly SmtpSettingsDto _smtpSettings;

        public UserController(IUserService userService, IOptions<SmtpSettingsDto> smtpSettings)
        {
            _userService = userService;
            _smtpSettings = smtpSettings.Value;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("EmailPassword")]
        public async Task<ActionResult<UserDto>> GetUserByEmailPassword(string email, string password)
        {
            var user = await _userService.GetUserByEmailPassword(email, password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("Email")]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> InsertUser(UserDto userDto)
        {
            userDto.VerificationEmailToken = GenerateResetToken(); // Tạo token xác minh email
            userDto.IsEmailVerified = false; // Đặt trạng thái email chưa được xác minh
            userDto.VerificationEmailTokenExpiry = DateTime.UtcNow.AddHours(7);

            var user = await _userService.InsertUser(userDto);
            if (user == null)
            {
                return BadRequest();
            }

            var verificationLink = GenerateVerificationLink(user.VerificationEmailToken);
            SendVerificationEmail(user.Email, verificationLink);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UserDto userDto, int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            userDto.Id = id;
            userDto.UpdatedAt = DateTime.UtcNow.AddHours(7);
            user = userDto;
            await _userService.UpdateUser(user);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userService.GetUserByEmail(email);

            if (user == null)
            {
                return NotFound(new { message = "Email does not exist in the system." });
            }

            user.PasswordResetToken = GenerateResetToken();
            user.PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(8);

            await _userService.UpdateUser(user);

            var resetLink = $"https://localhost:7059/User/ResetPassword?token={Uri.EscapeDataString(user.PasswordResetToken)}";
            SendResetPasswordEmail(user.Email, resetLink);

            return Ok(new { message = "Reset password link has been sent to your email." });
        }

        //[HttpGet("ResetPassword")]
        //public IActionResult ResetPassword(string token)
        //{
        //    var user = _userService.GetUserByPassToken(token);
        //    if (user == null)
        //    {
        //        return NotFound(new { message = "Token is invalid or expired." });
        //    }
        //    return Ok(new { message = "Token is valid, please change your password." });
        //}

        [HttpPost("PostResetPassword")]
        public async Task<IActionResult> PostResetPassword(ResetPasswordDto model)
        {
            var user = await _userService.GetUserByPassToken(model.Token);
            if (user == null)
            {
                return NotFound(new { message = "Token is invalid or expired." });
            }

            user.Password = model.NewPassword;
            user.PasswordResetToken = null;
            user.PasswordResetTokenExpiry = null;

            await _userService.UpdateUser(user);
            return Ok(user);
        }

        [HttpGet("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(string token)
        {
            var isVerified = await _userService.VerifyEmail(token);
            if (isVerified)
            {
                return Ok(new { message = "Email verified successfully." });
            }
            return BadRequest("Invalid or expired token.");
        }

        private string GenerateResetToken()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var tokenBytes = new byte[32];
                rng.GetBytes(tokenBytes);
                return Convert.ToBase64String(tokenBytes);
            }
        }

        private string GenerateVerificationLink(string token)
        {

            return $"https://localhost:7239/api/User/VerifyEmail?token={Uri.EscapeDataString(token)}";
        }

        private void SendResetPasswordEmail(string toEmail, string resetLink)
        {
            SendEmail(toEmail, "Password Reset Request",
                $"To reset your password, please click the following link: <a href=\"{resetLink}\">Reset Password</a>");
        }

        private void SendVerificationEmail(string toEmail, string verificationLink)
        {
            SendEmail(toEmail, "Email Verification Request",
                $"Please verify your email address by clicking the following link: <a href=\"{verificationLink}\">Verify Email</a>");
        }

        [HttpPost("SendVerificationEmail")]
        public async Task<IActionResult> SendVerificationEmail(UserDto userDto)
        {
            var token = GenerateResetToken(); // Generate a token
            userDto.VerificationEmailTokenExpiry = DateTime.UtcNow.AddHours(7);
            userDto.VerificationEmailToken = token;

            await _userService.UpdateUser(userDto);
            var verificationLink = Url.Action("VerifyEmail", "User", new { token }, Request.Scheme);

            string subject = "Verify your email address";
            string body = $"Please verify your email address by clicking the following link: <a href='{verificationLink}' style='text-decoration: none'>Verify Email</a>.";
            SendEmail(userDto.Email, subject, body);

            return Ok();
        }

        private void SendEmail(string toEmail, string subject, string body)
        {
            if (string.IsNullOrEmpty(_smtpSettings.Host) || string.IsNullOrEmpty(_smtpSettings.Username) || string.IsNullOrEmpty(_smtpSettings.Password))
            {
                throw new ArgumentException("SMTP Host, Username, or Password is not configured.");
            }

            var fromAddress = new MailAddress(_smtpSettings.Username, "Shopee Application");
            var toAddress = new MailAddress(toEmail);

            try
            {
                using (var smtpClient = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };
                    smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending email: {ex.Message}");
                throw;
            }
        }
    }
}
