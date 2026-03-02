using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.WebApplication.Abstract
{
    public interface IOfficeLocationService
    {
        Task<List<OfficeLocationListVM>> GetAllAsync();
        Task AddOfficeLocationAsync(OfficeLocationAddVM request);
        Task DeleteOfficeLocationAsync(Guid id);
        Task<OfficeLocationUpdateVM> GetOfficeLocationById(Guid id);
        Task UpdateOfficeLocationAsync(OfficeLocationUpdateVM request);
    }
}
