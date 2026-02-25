using AutoMapper;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using Checktify.Entity.WebApplication.ViewModels.WorkScheduleVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Automapper.WebApplication
{
    public class WorkScheduleMapper : Profile
    {
        public WorkScheduleMapper()
        {
            CreateMap<WorkSchedule, WorkScheduleListVM>().ReverseMap();
            CreateMap<WorkSchedule, WorkScheduleAddVM>().ReverseMap();
            CreateMap<WorkSchedule, WorkScheduleUpdateVM>().ReverseMap();
        }
    }
}
