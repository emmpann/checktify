using Checktify.Entity.Identity.Entities;
using Checktify.Entity.WebApplication.ViewModels.UserVM;
using Checktify.Service.Services.Identity.Abstract;
using Checktify.Service.Services.WebApplication.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Checktify.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _companyService;
        private readonly IWorkScheduleService _workScheduleService;
        private readonly IRoleService _roleService;

        public UserController(UserManager<AppUser> userManager, ICompanyService companyService, IWorkScheduleService workScheduleService, IRoleService roleService)
        {
            _userManager = userManager;
            _companyService = companyService;
            _workScheduleService = workScheduleService;
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var companies = await _companyService.GetAllAsync();
            var schedules = await _workScheduleService.GetAllAsync();
            var roles = await _roleService.GetAllAsync();
            var userRoles = await _userManager.GetRolesAsync(user);

            ViewBag.Companies = new SelectList(companies, "Id", "Name", user.CompanyId);
            ViewBag.WorkSchedules = new SelectList(schedules, "Id", "Name", user.WorkScheduleId);

            var model = new UserEditVM
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                CompanyId = user.CompanyId,
                WorkScheduleId = user.WorkScheduleId,
                SelectedRole = userRoles.FirstOrDefault(),
                Roles = roles.Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name,
                    Selected = userRoles.Contains(r.Name)
                })
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditVM model)
        {
            if (!ModelState.IsValid)
            {
                var companies = await _companyService.GetAllAsync();
                var schedules = await _workScheduleService.GetAllAsync();
                
                ViewBag.Companies = new SelectList(companies, "Id", "Name", model.CompanyId);
                ViewBag.WorkSchedules = new SelectList(schedules, "Id", "Name", model.WorkScheduleId);
                
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
                return NotFound();

            user.CompanyId = model.CompanyId;
            user.WorkScheduleId = model.WorkScheduleId;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                    ModelState.AddModelError(string.Empty, err.Description);

                var companies = await _companyService.GetAllAsync();
                var schedules = await _workScheduleService.GetAllAsync();
                ViewBag.Companies = new SelectList(companies, "Id", "Name", model.CompanyId);
                ViewBag.WorkSchedules = new SelectList(schedules, "Id", "Name", model.WorkScheduleId);
                return View(model);
            }
            
            if (!string.IsNullOrEmpty(model.SelectedRole))
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, model.SelectedRole);
            }

            return RedirectToAction("Index");
        }
    }
}
