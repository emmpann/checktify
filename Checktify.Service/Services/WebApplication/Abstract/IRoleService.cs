using Checktify.Entity.WebApplication.ViewModels.RoleVM;

namespace Checktify.Service.Services.WebApplication.Abstract
{
    public interface IRoleService
    {
        Task<List<RoleListVM>> GetAllAsync();
        Task AddRoleAsync(RoleAddVM request);
        Task DeleteRoleAsync(Guid id);
        Task<RoleUpdateVM> GetRoleById(Guid id);
        Task UpdateRoleAsync(RoleUpdateVM request);
    }
}
