using Checktify.Entity.WebApplication.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.Abstract
{
    public interface IUserService
    {
        Task<List<UserListVM>> GetAllAsync();
        Task AddUserAsync(UserAddVM request);
        Task DeleteUserAsync(Guid id);
        Task<UserUpdateVM> GetUserById(Guid id);
        Task UpdateUserAsync(UserUpdateVM request);
    }
}
