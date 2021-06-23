using Application.Commands.Users;
using Application.Queries.Users;
using Infra.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trello_.Data;
using Trello_.Extensions;
using Trello_.Models;
using Trello_.Services;

namespace Trello_.Controllers
{

    public class UserController : BaseController
    {

       
        private readonly IHttpContextAccessor _accessor;
        private readonly IMediator _mediator;

        public UserController( IHttpContextAccessor accessor, IMediator mediator)
        {
            _mediator = mediator;
            _accessor = accessor;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Register([FromBody] RegisterCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginQuery model)
        {
            return await _mediator.Send(model); 
        }


        [HttpPost]
        public async Task<ActionResult<string>> RegisterAdmin([FromBody] RegisterAdminCommand model)
        {

            return await _mediator.Send(model);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Test()
        {
            return Ok(_accessor.GetUserId());
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public IActionResult TestAdmin()
        {
            return Ok(_accessor.GetUserId());
        }
    }
}
