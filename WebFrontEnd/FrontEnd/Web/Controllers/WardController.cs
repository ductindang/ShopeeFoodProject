using BusinessLogicLayerFront.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class WardController : Controller
    {
        private readonly IWardService _wardService;

        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetWardsByDistrict(string districtId)
        {
            var wards = await _wardService.GetWardsByDistrict(districtId);
            return Json(wards);
        }
    }
}
