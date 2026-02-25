using AutoMapper;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.AttendanceVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Automapper.WebApplication
{
    public class AttendanceMapper : Profile
    {
        public AttendanceMapper()
        {
            CreateMap<Attendance, AttendanceListVM>().ReverseMap();
            CreateMap<Attendance, AttendanceAddVM>().ReverseMap();
            CreateMap<Attendance, AttendanceUpdateVM>().ReverseMap();
        }
    }
}
