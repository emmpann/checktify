using AutoMapper;
using Checktify.Entity.Identity.Entities;
using Checktify.Entity.WebApplication.ViewModels.RoleVM;

namespace Checktify.Service.Automapper.Identity
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
