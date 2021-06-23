using Application.Commands.Users;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trello_.Models;
using Trello_.Services;

namespace Application.CommandHandlers.Users
{
    public class ReigsterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public ReigsterCommandHandler(UserManager<ApplicationUser> usermanager,IJwtService jwtService, IMapper mapper)
        {
            _mapper = mapper;
            _jwtService = jwtService;
            _usermanager = usermanager;
        }


        public async  Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            await _usermanager.CreateAsync(user, request.Password);
            var token = await _jwtService.GetTokenAsync(user);
            return token;
        }
    }
}
