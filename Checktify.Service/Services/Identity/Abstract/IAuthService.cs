using Checktify.Entity.DTOs.Authentication;
using Checktify.Entity.DTOs.General;

namespace Checktify.Service.Services.Identity.Abstract
{
    public interface IAuthService
    {
        Task<RegisterResult> RegisterAsync(RegisterRequest request);
        Task<LoginResult> LoginAsync(LogInRequest request);
    }
}
