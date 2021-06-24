using Application.Commands.Admin;
using AutoMapper;
using Infra.Models;
using Infra.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trello_.Extensions;

namespace Application.CommandHandlers.Admin
{
    class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public AddTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var usertask = _mapper.Map<UserTask>(request);
            usertask.AdminId = _accessor.GetUserId();
            await _unitOfWork.AdminRepository.AddTaskAsync(usertask);
            await _unitOfWork.SaveChangesAsync();
            return usertask.Id;
        }
    }
}
