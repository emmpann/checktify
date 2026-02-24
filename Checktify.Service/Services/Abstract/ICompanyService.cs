using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.Abstract
{
    public interface ICompanyService
    {
        Task<List<CompanyListVM>> GetAllAsync();
        Task AddCompanyAsync(CompanyAddVM request);
        Task DeleteCompanyAsync(Guid id);
        Task<CompanyUpdateVM> GetCompanyById(Guid id);
        Task UpdateCompanyAsync(CompanyUpdateVM request);
    }
}
