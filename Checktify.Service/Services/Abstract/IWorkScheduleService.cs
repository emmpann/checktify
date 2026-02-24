using Checktify.Entity.WebApplication.ViewModels.WorkScheduleVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.Abstract
{
    public interface IWorkScheduleService
    {
        Task<List<WorkScheduleListVM>> GetAllAsync();
        Task AddWorkScheduleAsync(WorkScheduleAddVM request);
        Task DeleteWorkScheduleAsync(Guid id);
        Task<WorkScheduleUpdateVM> GetWorkScheduleById(Guid id);
        Task UpdateWorkScheduleAsync(WorkScheduleUpdateVM request);
    }
}
