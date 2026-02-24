using AutoMapper;
using AutoMapper.QueryableExtensions;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.WorkScheduleVM;
using Checktify.Repository.Repositories.Abstract;
using Checktify.Repository.UnitOfWorks.Abstract;
using Checktify.Service.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Checktify.Service.Services.Concrete
{
    public class WorkScheduleService : IWorkScheduleService
    {
        private readonly IGenericRepositories<WorkSchedule> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<WorkSchedule>();
        }

        public async Task<List<WorkScheduleListVM>> GetAllAsync()
        {
            var workSchedules = await _repository.GetAllEntityList().ProjectTo<WorkScheduleListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return workSchedules;
        }

        public async Task AddWorkScheduleAsync(WorkScheduleAddVM request)
        {
            var workSchedule = _mapper.Map<WorkSchedule>(request);
            await _repository.AddEntityAsync(workSchedule);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteWorkScheduleAsync(Guid id)
        {
            var workSchedule = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(workSchedule);
            await _unitOfWork.CommitAsync();
        }

        public async Task<WorkScheduleUpdateVM> GetWorkScheduleById(Guid id)
        {
            var user = await _repository.Where(x => x.Id == id).ProjectTo<WorkScheduleUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return user;
        }

        public async Task UpdateWorkScheduleAsync(WorkScheduleUpdateVM request)
        {
            var workSchedule = _mapper.Map<WorkSchedule>(request);
            _repository.UpdateEntity(workSchedule);
            await _unitOfWork.CommitAsync();
        }
    }
}
