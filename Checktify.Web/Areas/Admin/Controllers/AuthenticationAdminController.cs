using Checktify.Entity.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Checktify.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticationAdminController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AuthenticationAdminController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Authentication/Login");
        }
    }
}
