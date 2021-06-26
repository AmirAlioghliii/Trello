using Application.Commands.Customers;
using Application.Queries.Customers;
using AutoMapper;
using Infra.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trello_.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerCntroller : BaseController
    {
        private readonly IMediator _mediator;

        public CustomerCntroller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IEnumerable<UserTask>> GetAllTasksByCategory(CustomrGetAllQuery model)
        {
           return await _mediator.Send(model);
        }

        [HttpPut]
        public async Task<int> ChangeTasksStatus(CustomerChangeStatusCommand model)
        {
            return await _mediator.Send(model);
        }

    }
}
