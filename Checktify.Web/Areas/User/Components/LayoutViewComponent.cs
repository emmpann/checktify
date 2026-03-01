using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Checktify.Web.Areas.User.Components
{
    public class LayoutViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;

        public LayoutViewComponent(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string Username)
        {
            if (Username == null)
            {
                Username = User.Identity!.Name!;
            }

            var user = await userManager.FindByNameAsync(Username);

            if (user!.FileName == null)
            {
                return View(new UserPictureVM { FileName = "Default"});
            }


            return View(new UserPictureVM { FileName = user.FileName });
        }
    }
}
