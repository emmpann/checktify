using Checktify.Service.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Checktify.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        public DashboardController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        public async Task<IActionResult> Index()
        {
            var attendances = await _attendanceService.GetAllAsync();

            return View(attendances);
        }
    }
}
