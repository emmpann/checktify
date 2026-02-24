using AutoMapper;
using AutoMapper.QueryableExtensions;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.AttendanceVM;
using Checktify.Repository.Repositories.Abstract;
using Checktify.Repository.UnitOfWorks.Abstract;
using Checktify.Service.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.Concrete
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IGenericRepositories<Attendance> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AttendanceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Attendance>();
        }

        public async Task<List<AttendanceListVM>> GetAllAsync()
        {
            var attendances = await _repository.GetAllEntityList().ProjectTo<AttendanceListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return attendances;
        }

        public async Task AddAttendanceAsync(AttendanceAddVM request)
        {
            var attendance = _mapper.Map<Attendance>(request);
            await _repository.AddEntityAsync(attendance);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAttendanceAsync(Guid id)
        {
            var attendance = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(attendance);
            await _unitOfWork.CommitAsync();
        }

        public async Task<AttendanceUpdateVM> GetAttendanceById(Guid id)
        {
            var attendance = await _repository.Where(x => x.Id == id).ProjectTo<AttendanceUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return attendance;
        }

        public async Task UpdateAttendanceAsync(AttendanceUpdateVM request)
        {
            var attendance = _mapper.Map<Attendance>(request);
            _repository.UpdateEntity(attendance);
            await _unitOfWork.CommitAsync();
        }
    }
}
