using AutoMapper;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using Checktify.Entity.WebApplication.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Automapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserListVM>().ReverseMap();
            CreateMap<User, UserAddVM>().ReverseMap();
            CreateMap<User, UserUpdateVM>().ReverseMap();
        }
    }
}
