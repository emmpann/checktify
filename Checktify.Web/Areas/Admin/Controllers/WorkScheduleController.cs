using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using Checktify.Entity.WebApplication.ViewModels.WorkScheduleVM;
using Checktify.Service.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Checktify.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class WorkScheduleController : Controller
    {
        private readonly IWorkScheduleService _workScheduleService;
        private readonly IOfficeLocationService _officeLocationService;

        public WorkScheduleController(
            IWorkScheduleService workScheduleService,
            IOfficeLocationService officeLocationService)
        {
            _workScheduleService = workScheduleService;
            _officeLocationService = officeLocationService;
        }

        public async Task<IActionResult> GetWorkScheduleList()
        {
            var workSchedules = await _workScheduleService.GetAllAsync();
            return View(workSchedules);
        }

        [HttpGet]
        public async Task<IActionResult> AddWorkSchedule()
        {
            var officeLocations = await _officeLocationService.GetAllAsync();

            ViewBag.OfficeLocations = officeLocations
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkSchedule(WorkScheduleAddVM request)
        {
            await _workScheduleService.AddWorkScheduleAsync(request);
            return RedirectToAction("GetWorkScheduleList", "WorkSchedule", new { Area = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWorkSchedule(Guid id)
        {
            var workSchedule = await _workScheduleService.GetWorkScheduleById(id);
            return View(workSchedule);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWorkSchedule(WorkScheduleUpdateVM request)
        {
            await _workScheduleService.UpdateWorkScheduleAsync(request);
            return RedirectToAction("GetWorkScheduleList", "WorkSchedule", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteWorkSchedule(Guid id)
        {
            await _workScheduleService.DeleteWorkScheduleAsync(id);
            return RedirectToAction("GetWorkScheduleList", "WorkSchedule", new { Area = ("Admin") });
        }
    }
}
