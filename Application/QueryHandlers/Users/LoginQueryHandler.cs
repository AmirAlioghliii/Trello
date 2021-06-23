using Application.Queries.Users;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trello_.Data;
using Trello_.Models;
using Trello_.Services;

namespace Application.QueryHandlers.Users
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly IJwtService _jwtService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public LoginQueryHandler(IJwtService jwtService, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, IMapper mapper)
        {
            _jwtService = jwtService;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            var user = await _context.ApplicationUsers.SingleOrDefaultAsync(u => u.Email == request.Email);

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if (!result.Succeeded)
            {
                return string.Empty;
            }

            var token = await _jwtService.GetTokenAsync(user);

            return token;
        }
    }
}
