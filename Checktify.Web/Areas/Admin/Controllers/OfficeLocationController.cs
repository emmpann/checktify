using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using Checktify.Service.Services.Abstract;
using Checktify.Service.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Checktify.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfficeLocationController : Controller
    {
        private readonly IOfficeLocationService _officeLocationService;
        private readonly ICompanyService _companyService;

        public OfficeLocationController(
            IOfficeLocationService officeLocation,
            ICompanyService companyService)
        {
            _officeLocationService = officeLocation;
            _companyService = companyService;
        }

        public async Task<IActionResult> GetOfficeLocationList()
        {
            var companies = await _officeLocationService.GetAllAsync();
            return View(companies);
        }

        [HttpGet]
        public async Task<IActionResult> AddOfficeLocation()
        {
            var companies = await _companyService.GetAllAsync();

            ViewBag.Companies = companies
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOfficeLocation(OfficeLocationAddVM request)
        {
            await _officeLocationService.AddOfficeLocationAsync(request);
            return RedirectToAction("GetOfficeLocationList", "OfficeLocation", new { Area = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOfficeLocation(Guid id)
        {
            var company = await _officeLocationService.GetOfficeLocationById(id);
            return View(company);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOfficeLocation(OfficeLocationUpdateVM request)
        {
            await _officeLocationService.UpdateOfficeLocationAsync(request);
            return RedirectToAction("GetOfficeLocationList", "OfficeLocation", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteOfficeLocation(Guid id)
        {
            await _officeLocationService.DeleteOfficeLocationAsync(id);
            return RedirectToAction("GetOfficeLocationList", "OfficeLocation", new { Area = ("Admin") });
        }
    }
}
