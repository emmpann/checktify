using AutoMapper;
using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using Checktify.Entity.WebApplication.ViewModels.UserVM;

namespace Checktify.Service.Automapper.Identity
{
    public class SignUpMapper : Profile
    {
        public SignUpMapper()
        {
            CreateMap<AppUser, SignUpVM>().ReverseMap();
            //CreateMap<User, UserAddVM>().ReverseMap();
            //CreateMap<User, UserUpdateVM>().ReverseMap();
        }
    }
}
