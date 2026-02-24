using AutoMapper;
using AutoMapper.QueryableExtensions;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.RoleVM;
using Checktify.Entity.WebApplication.ViewModels.UserVM;
using Checktify.Repository.Repositories.Abstract;
using Checktify.Repository.UnitOfWorks.Abstract;
using Checktify.Service.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IGenericRepositories<User> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<User>();
        }

        public async Task<List<UserListVM>> GetAllAsync()
        {
            var users = await _repository.GetAllEntityList().ProjectTo<UserListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return users;
        }

        public async Task AddUserAsync(UserAddVM request)
        {
            var user = _mapper.Map<User>(request);
            await _repository.AddEntityAsync(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<UserUpdateVM> GetUserById(Guid id)
        {
            var user = await _repository.Where(x => x.Id == id).ProjectTo<UserUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return user;
        }

        public async Task UpdateUserAsync(UserUpdateVM request)
        {
            var user = _mapper.Map<User>(request);
            _repository.UpdateEntity(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
