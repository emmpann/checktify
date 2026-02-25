using Checktify.Entity.Identity.Entities;
using Checktify.Entity.WebApplication.ViewModels.AttendanceVM;
using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using Checktify.Service.Services.Abstract;
using Checktify.Service.Services.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Checktify.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IWorkScheduleService _workScheduleService;
        private readonly IOfficeLocationService _officeLocationService;
        private readonly UserManager<User> _userManager;

        public AttendanceController(IAttendanceService attendanceService, UserManager<User> userManager, IWorkScheduleService workScheduleService, IOfficeLocationService officeLocationService)
        {
            _attendanceService = attendanceService;
            _userManager = userManager;
            _workScheduleService = workScheduleService;
            _officeLocationService = officeLocationService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var attendances = await _attendanceService.GetAllAsync();
            var workSchedules = await _workScheduleService.GetAllAsync();
            var officeLocations = await _officeLocationService.GetAllAsync();

            var a = attendances.Include


            return View(attendances);
        }

        [HttpGet]
        public IActionResult AddAttendance()
        {
            return View(new AttendanceAddVM()); 
        }

        [HttpPost]
        public async Task<IActionResult> CheckIn(AttendanceAddVM request)
        {
            var user = await _userManager.GetUserAsync(User);
            request.UserId = user.Id;
            request.CheckInTime = DateTime.Now;
            request.CompanyId = (Guid)user.CompanyId;
            var workSchedule = await _workScheduleService.GetWorkScheduleById(user.WorkScheduleId ?? Guid.Empty);
            request.CheckInOfficeLocationId = workSchedule.OfficeLocationId;
            request.CheckOutOfficeLocationId = null;
            await _attendanceService.AddAttendanceAsync(request);
            return RedirectToAction("Index", "Attendance", new { Area = ("Admin") });
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(AttendanceAddVM request)
        {
            var user = await _userManager.GetUserAsync(User);
            request.UserId = user.Id;
            request.CheckOutTime = DateTime.Now;
            request.CheckOutOfficeLocationId = request.CheckInOfficeLocationId;
            await _attendanceService.AddAttendanceAsync(request);
            return RedirectToAction("Index", "Attendance", new { Area = ("Admin") });
        }
    }
}
