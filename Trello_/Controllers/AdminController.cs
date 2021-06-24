using Application.Commands.Admin;
using Application.Queries.Admin;
using AutoMapper;
using Infra.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Trello_.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class AdminController : BaseController
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        public async Task<int> Newtask(AddTaskCommand model)
        {
           return await _mediator.Send(model);
        }


        [HttpPost]
        public async Task<IEnumerable<UserTask>> GetAllTasks(AdminGetAllQuery model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        public async Task<IEnumerable<UserTask>> GetArchiveTasks( AdminArchiveTasksQuery model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        public async Task<int> AddNewCategory(AdminAddCategoryCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        public async Task<int> ChangeTasksStaus(ChangeStatusCommand model)
        {
            return await _mediator.Send(model);
        }
    }
}
