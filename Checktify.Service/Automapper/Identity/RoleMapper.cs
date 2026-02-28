using AutoMapper;
using Checktify.Entity.Identity.Entities;
using Checktify.Entity.WebApplication.ViewModels.RoleVM;

namespace Checktify.Service.Automapper.Identity
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<AppRole, RoleListVM>().ReverseMap();
            CreateMap<AppRole, RoleAddVM>().ReverseMap();
            CreateMap<AppRole, RoleUpdateVM>().ReverseMap();
        }
    }
}
