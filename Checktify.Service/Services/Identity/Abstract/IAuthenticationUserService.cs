using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Checktify.Service.Services.Identity.Abstract
{
    public interface IAuthenticationUserService
    {
        Task<UserEditVM> GetUserEditVMAsync(HttpContext httpContext);
        Task<IdentityResult> UserEditAsync(UserEditVM request, AppUser user);
    }
}
