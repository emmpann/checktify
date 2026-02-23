using AutoMapper;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Automapper
{
    public class OfficeLocationMapper : Profile
    {
        public OfficeLocationMapper()
        {
            CreateMap<OfficeLocation, OfficeLocationListVM>().ReverseMap();
            CreateMap<OfficeLocation, OfficeLocationAddVM>().ReverseMap();
            CreateMap<OfficeLocation, OfficeLocationUpdateVM>().ReverseMap();
        }
    }
}
