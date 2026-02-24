using Checktify.Entity.WebApplication.ViewModels.RoleVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.Abstract
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
