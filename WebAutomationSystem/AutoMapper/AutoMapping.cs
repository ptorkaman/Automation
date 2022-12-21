using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models;
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
            CreateMap<ApplicationRoles, RoleViewModel>().ReverseMap();
            CreateMap<RolePattern, RolePatternViewModel>().ReverseMap();
            CreateMap<AdministrativeForm, AdministrativeFormViewModel>().ReverseMap();
            CreateMap<Letters, LettersViewModel>().ReverseMap();
            CreateMap<ForeignDocument, ForeignDocumentViewModel>().ReverseMap();

            CreateMap<News, NewsCreateCommandModel>().ReverseMap();
            CreateMap<News, NewsUpdateCommandModel>().ReverseMap();
            CreateMap<Cartable, Cartable>().ReverseMap();
        }
    }
}
