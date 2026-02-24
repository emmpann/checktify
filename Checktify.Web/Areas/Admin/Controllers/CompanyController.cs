using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using Checktify.Service.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Checktify.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult GetCompanyList()
        {
            var companies = _companyService.GetAllAsync();
            return View(companies);
        }

        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyAddVM request)
        {
            await _companyService.AddCompanyAsync(request);
            return RedirectToAction("GetCompanyList", "CompanyController", new { Area = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyById(Guid id)
        {
            var company = await _companyService.GetCompanyById(id);
            return View(company);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompany(CompanyUpdateVM request)
        {
            await _companyService.UpdateCompanyAsync(request);
            return RedirectToAction("GetCompanyList", "CompanyController", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _companyService.DeleteCompanyAsync(id);
            return RedirectToAction("GetCompanyList", "CompanyController", new { Area = ("Admin") });
        }
    }
}
