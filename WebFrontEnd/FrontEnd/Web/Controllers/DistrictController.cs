using BusinessLogicLayerFront.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class DistrictController : Controller
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService ditrictService)
        {
            _districtService = ditrictService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetDistrictByProvince(string provinceId)
        {
            var districts = await _districtService.GetDistrictsByProvince(provinceId);
            return Json(districts);
        }
    }
}
