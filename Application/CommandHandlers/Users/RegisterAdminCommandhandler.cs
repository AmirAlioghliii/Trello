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
using Trello_.Data;
using Trello_.Models;
using Trello_.Services;

namespace Application.CommandHandlers.Users
{
    public class RegisterAdminCommandhandler : IRequestHandler<RegisterAdminCommand, string>
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IJwtService _jwtservice;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public RegisterAdminCommandhandler(IJwtService jwtservice, UserManager<ApplicationUser> usermanager, IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _jwtservice = jwtservice;
            _usermanager = usermanager;
            _mapper = mapper;
        }

        public async Task<string> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            var transaction = _context.Database.BeginTransaction();

            var result =await _usermanager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return string.Empty;
            }

            var roleresult = await _usermanager.AddToRoleAsync(user, "Admin");
            if (!roleresult.Succeeded)
            {
                transaction.Rollback();
                return string.Empty;
            }

            transaction.Commit();
            var token =await _jwtservice.GetTokenAsync(user);

            return (token);
        }
    }
}
