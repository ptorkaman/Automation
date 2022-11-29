using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ApplicationUsers, UserViewModel>().ReverseMap();
            CreateMap<JobsChart, JobsChartViewModel>().ReverseMap();
            CreateMap<Reminder, ReminderViewModel>().ReverseMap();
        }
    }
}
