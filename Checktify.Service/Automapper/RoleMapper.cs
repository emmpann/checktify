using AutoMapper;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using Checktify.Entity.WebApplication.ViewModels.RoleVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Automapper
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleListVM>().ReverseMap();
            CreateMap<Role, RoleAddVM>().ReverseMap();
            CreateMap<Role, RoleUpdateVM>().ReverseMap();
        }
    }
}
