using Checktify.Entity.WebApplication.ViewModels.AttendanceVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.Abstract
{
    public interface IAttendanceService
    {
        Task<List<AttendanceListVM>> GetAllAsync();
        Task AddAttendanceAsync(AttendanceAddVM request);
        Task DeleteAttendanceAsync(Guid id);
        Task<AttendanceUpdateVM> GetAttendanceById(Guid id);
        Task UpdateAttendanceAsync(AttendanceUpdateVM request);
    }
}
