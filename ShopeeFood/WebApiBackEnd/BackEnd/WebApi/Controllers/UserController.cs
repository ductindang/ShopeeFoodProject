using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
            var user = await _userService.GetByUserId(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetByEmailPassword")]
        public async Task<ActionResult<UserDto>> GetUserByEmailPassword(string email, string password)
        {
            var user = await _userService.GetUserByEmailPassword(email, password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetUserByEmail")]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        } 


        [HttpPost("InsertUser")]
        public async Task<ActionResult<UserDto>> InsertUser(UserDto userDto)
        {
            var user = await _userService.InsertUser(userDto);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteByUserId(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


    }
}
