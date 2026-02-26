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
            CreateMap<Attendance, AttendanceListVM>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : null))
                .ForMember(dest => dest.CheckInOfficeLocationName, opt => opt.MapFrom(src => src.CheckInOfficeLocation != null ? src.CheckInOfficeLocation.Name : null))
                .ForMember(dest => dest.CheckOutOfficeLocationName, opt => opt.MapFrom(src => src.CheckOutOfficeLocation != null ? src.CheckOutOfficeLocation.Name : null))
                .ForMember(dest => dest.WorkScheduleCheckOutTime, opt => opt.MapFrom(src => src.User != null && src.User.WorkSchedule != null ? (TimeSpan?)src.User.WorkSchedule.CheckOutTime : null))
                .ForMember(dest => dest.WorkScheduleName, opt => opt.MapFrom(src => src.User != null && src.User.WorkSchedule != null ? src.User.WorkSchedule.Name : null))
                .ReverseMap();
            CreateMap<Attendance, AttendanceAddVM>().ReverseMap();
            CreateMap<Attendance, AttendanceUpdateVM>().ReverseMap();
        }
    }
}
