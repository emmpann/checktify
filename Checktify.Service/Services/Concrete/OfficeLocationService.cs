using AutoMapper;
using AutoMapper.QueryableExtensions;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using Checktify.Repository.Repositories.Abstract;
using Checktify.Repository.UnitOfWorks.Abstract;
using Checktify.Service.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.Concrete
{
    public class OfficeLocationService : IOfficeLocationService
    {
        private readonly IGenericRepositories<OfficeLocation> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfficeLocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<OfficeLocation>();
        }

        public async Task<List<OfficeLocationListVM>> GetAllAsync()
        {
            var officeLocations = await _repository.GetAllEntityList().ProjectTo<OfficeLocationListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return officeLocations;
        }

        public async Task AddOfficeLocationAsync(OfficeLocationAddVM request)
        {
            var officeLocation = _mapper.Map<OfficeLocation>(request);
            await _repository.AddEntityAsync(officeLocation);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteOfficeLocationAsync(Guid id)
        {
            var officeLocation = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(officeLocation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<OfficeLocationUpdateVM> GetOfficeLocationById(Guid id)
        {
            var officeLocation = await _repository.Where(x => x.Id == id).ProjectTo<OfficeLocationUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return officeLocation;
        }

        public async Task UpdateOfficeLocationAsync(OfficeLocationUpdateVM request)
        {
            var officeLocation = _mapper.Map<OfficeLocation>(request);
            _repository.UpdateEntity(officeLocation);
            await _unitOfWork.CommitAsync();
        }
    }
}
