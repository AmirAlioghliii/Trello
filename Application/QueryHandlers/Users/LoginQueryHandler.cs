using Application.Queries.Users;
using Infra.Services;
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

namespace Application.QueryHandlers.Users
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public LoginQueryHandler(SignInManager<ApplicationUser> signInManager,IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }


        

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
          var user=  await _unitOfWork.UserRepository.GetUserByEmailAsync(request.Email);

            var result =await _signInManager.PasswordSignInAsync(user, request.Password,false,false);

            if (!result.Succeeded)
            {
                return string.Empty;
            }
            return await _jwtService.GetTokenAsync(user);

        }
    }
}
