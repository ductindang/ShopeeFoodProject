using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly IWardService _wardService;

        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<WardRequest>>> GetAllWards()
        {
            var wards = await _wardService.GetAllWards(); // Assuming this returns IEnumerable<StoreDto>
            return Ok(wards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WardRequest>> GetWardById(string id)
        {
            var ward = await _wardService.GetWardById(id); // Assuming this returns StoreDto
            if (ward == null)
            {
                return NotFound();
            }
            return Ok(ward);
        }

        [HttpGet("District/{districtId}")]
        public async Task<ActionResult<IEnumerable<WardRequest>>> GetWardsByDistrict(string districtId)
        {
            var wards = await _wardService.GetWardsByDistrict(districtId);
            if (wards == null || !wards.Any())
            {
                return NotFound();
            }
            return Ok(wards);
        }
    }
}
