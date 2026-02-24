using AutoMapper;
using AutoMapper.QueryableExtensions;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using Checktify.Entity.WebApplication.ViewModels.RoleVM;
using Checktify.Repository.Repositories.Abstract;
using Checktify.Repository.UnitOfWorks.Abstract;
using Checktify.Service.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IGenericRepositories<Role> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Role>();
        }

        public async Task<List<RoleListVM>> GetAllAsync()
        {
            var roles = await _repository.GetAllEntityList().ProjectTo<RoleListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return roles;
        }

        public async Task AddRoleAsync(RoleAddVM request)
        {
            var role = _mapper.Map<Role>(request);
            await _repository.AddEntityAsync(role);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            var role = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(role);
            await _unitOfWork.CommitAsync();
        }

        public async Task<RoleUpdateVM> GetRoleById(Guid id)
        {
            var role = await _repository.Where(x => x.Id == id).ProjectTo<RoleUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return role;
        }

        public async Task UpdateRoleAsync(RoleUpdateVM request)
        {
            var role = _mapper.Map<Role>(request);
            _repository.UpdateEntity(role);
            await _unitOfWork.CommitAsync();
        }
    }
}
