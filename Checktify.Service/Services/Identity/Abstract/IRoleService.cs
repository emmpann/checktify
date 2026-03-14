using Checktify.Entity.WebApplication.ViewModels.AttendanceVM;
using Checktify.Entity.WebApplication.ViewModels.RoleVM;
using Microsoft.AspNetCore.Identity;

namespace Checktify.Service.Services.Identity.Abstract
{
    public interface IRoleService
    {
        Task<List<RoleListVM>> GetAllAsync();
        Task<IdentityResult> AddRoleAsync(RoleAddVM request);
        Task DeleteRoleAsync(Guid id);
        Task<RoleUpdateVM> GetRoleById(Guid id);
        Task<IdentityResult> UpdateRoleAsync(RoleUpdateVM request);
    }
}
