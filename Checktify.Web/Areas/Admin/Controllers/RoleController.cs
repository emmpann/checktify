using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using Checktify.Entity.WebApplication.ViewModels.RoleVM;
using Checktify.Service.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Checktify.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(
            IRoleService officeLocation)
        {
            _roleService = officeLocation;
        }

        public async Task<IActionResult> GetRoleList()
        {
            var companies = await _roleService.GetAllAsync();
            return View(companies);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleAddVM request)
        {
            await _roleService.AddRoleAsync(request);
            return RedirectToAction("GetRoleList", "Role", new { Area = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(Guid id)
        {
            var company = await _roleService.GetRoleById(id);
            return View(company);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateVM request)
        {
            await _roleService.UpdateRoleAsync(request);
            return RedirectToAction("GetRoleList", "Role", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteRole(Guid id)
        {
            await _roleService.DeleteRoleAsync(id);
            return RedirectToAction("GetRoleList", "Role", new { Area = ("Admin") });
        }
    }
}
