using AutoMapper;
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
            CreateMap<User, LogInVM>().ReverseMap();
        }
    }
}
