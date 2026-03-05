using AutoMapper;
using AutoMapper.QueryableExtensions;
using Checktify.Entity.Identity.Entities;
using Checktify.Entity.WebApplication.ViewModels.RoleVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Checktify.Service.Services.WebApplication.Concrete
{
    public class RoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> AddRoleAsync(RoleAddVM request)
        {
            if (!_roleManager.RoleExistsAsync(request.Name).Result)
            {
                return await _roleManager.CreateAsync(new AppRole { Name = request.Name });
            }
            var errors = new IdentityError() { Code = "RoleAlreadyExist", Description = "Role is already exist" };
            var result = IdentityResult.Failed(errors);
            return result;
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            var role = _roleManager.FindByIdAsync(id.ToString()).Result;
            _ = _roleManager.DeleteAsync(role!);
        }

        public async Task<List<RoleListVM>> GetAllAsync()
        {
            return await _roleManager.Roles.ProjectTo<RoleListVM>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<RoleUpdateVM> GetRoleById(Guid id)
        {
            //return _roleManager.FindByIdAsync(id.ToString())
            //return;
        }

        public async Task<IdentityResult> UpdateRoleAsync(RoleUpdateVM request)
        {
            var updatedRole = _roleManager.FindByIdAsync(request.Id.ToString());
            var mappedRole = _mapper.Map(request, updatedRole.Result);
            var result = await _roleManager.UpdateAsync(mappedRole!);

            return result;
        }
    }
}
