using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.Abstract
{
    public interface IAuthenticationCustomService
    {
        Task CreateResetCredentialsAndSend(AppUser user, HttpContext context, IUrlHelper url, ForgotPasswordVM request);
    }
}
