using AutoMapper;
using Checktify.Entity.DTOs.Authentication;
using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Automapper.Identity
{
    public class LogInMapper : Profile
    {
        public LogInMapper()
        {
            CreateMap<AppUser, LogInVM>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
