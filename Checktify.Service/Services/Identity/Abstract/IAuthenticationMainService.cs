using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Checktify.Service.Services.Identity.Abstract
{
    public interface IAuthenticationMainService
    {
        Task CreateResetCredentialsAndSend(AppUser user, HttpContext context, IUrlHelper url, ForgotPasswordVM request);
    }
}
