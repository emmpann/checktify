using AutoMapper;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.AttendanceVM;
using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Automapper.WebApplication
{
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            CreateMap<Company, CompanyListVM>().ReverseMap();
            CreateMap<Company, CompanyAddVM>().ReverseMap();
            CreateMap<Company, CompanyUpdateVM>().ReverseMap();
        }
    }
}
