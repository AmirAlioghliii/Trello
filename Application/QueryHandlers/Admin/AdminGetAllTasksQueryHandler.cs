using Application.Queries.Admin;
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

namespace Application.QueryHandlers.Admin
{
    public class AdminGetAllTasksQueryHandler : IRequestHandler<AdminGetAllQuery, IEnumerable<UserTask>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;


        public AdminGetAllTasksQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<UserTask>> Handle(AdminGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.AdminRepository.GetAllTasks(_accessor.GetUserId());
        }
    }
}
