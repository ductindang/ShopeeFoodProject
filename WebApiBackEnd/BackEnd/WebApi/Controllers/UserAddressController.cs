using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddressService _userAddressService;

        public UserAddressController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAddressRequest>>> GetAllUserAddresses()
        {
            var userAddresses = await _userAddressService.GetAllUserAddresses(); 
            return Ok(userAddresses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAddressRequest>> GetUserAddressById(int id)
        {
            var userAddress = await _userAddressService.GetUserAddressById(id); 
            if (userAddress == null)
            {
                return NotFound();
            }
            return Ok(userAddress);
        }

        [HttpPost]
        public async Task<ActionResult<UserAddressRequest>> InsertUserAddress([FromBody] BaseUserAddress baseUserAddress)
        {
            var userAddress = await _userAddressService.InsertUserAddress(baseUserAddress); 

            if (userAddress == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetUserAddressById), new { id = userAddress.Id }, userAddress);
        }

        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<UserAddressRequest>>> GetAllUserAddressesByUser(int userId)
        {
            var userAddresses = await _userAddressService.GetAllUserAddressesByUser(userId);
            if (!userAddresses.Any() || userAddresses == null)
            {
                return NotFound();
            }
            return Ok(userAddresses);
        }

        [HttpGet("{id}/UserAddressDetail")]
        public async Task<ActionResult<UserAddressDetailDto>> GetUserAddressDetailById(int id)
        {
            var userAddressDetail = await _userAddressService.GetUserAddressDetailById(id);
            if(userAddressDetail == null)
            {
                return NotFound();
            }
            return Ok(userAddressDetail);
        }
    }
}
