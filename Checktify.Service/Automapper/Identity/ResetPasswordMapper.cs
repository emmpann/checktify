using AutoMapper;
using Checktify.Entity.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Automapper.Identity
{
    public class ResetPasswordMapper : Profile
    {
        public ResetPasswordMapper()
        {
            CreateMap<AppUser, ResetPasswordMapper>().ReverseMap();
        }
    }
}
