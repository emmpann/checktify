using AutoMapper;
using AutoMapper.QueryableExtensions;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.AttendanceVM;
using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using Checktify.Repository.Repositories.Abstract;
using Checktify.Repository.UnitOfWorks.Abstract;
using Checktify.Service.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Checktify.Service.Services.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepositories<Company> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Company>();
        }

        public async Task<List<CompanyListVM>> GetAllAsync()
        {
            var companies = await _repository.GetAllEntityList().ProjectTo<CompanyListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return companies;
        }

        public async Task AddCompanyAsync(CompanyAddVM request)
        {
            var company = _mapper.Map<Company>(request);
            await _repository.AddEntityAsync(company);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCompanyAsync(Guid id)
        {
            var company = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(company);
            await _unitOfWork.CommitAsync();
        }

        public async Task<CompanyUpdateVM> GetCompanyById(Guid id)
        {
            var company = await _repository.Where(x => x.Id == id).ProjectTo<CompanyUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return company;
        }

        public async Task UpdateCompanyAsync(CompanyUpdateVM request)
        {
            var company = _mapper.Map<Company>(request);
            _repository.UpdateEntity(company);
            await _unitOfWork.CommitAsync();
        }
    }
}
