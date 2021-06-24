using Application.Commands.Admin;
using Application.Commands.Users;
using Application.Queries.Users;
using AutoMapper;
using Infra.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Models;

namespace Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterCommand, ApplicationUser>()
                .ForMember(p => p.UserName, p => p.MapFrom(o => o.Email));
            CreateMap<LoginQuery, ApplicationUser>();
            CreateMap<RegisterAdminCommand, ApplicationUser>()
                .ForMember(p=>p.UserName,p=>p.MapFrom(o=>o.Email));
            CreateMap<AddTaskCommand, UserTask>().ForMember(a => a.Status, a => a.MapFrom(a => "Created"));
            CreateMap<AdminAddCategoryCommand, Category>();
        }
    }
}
