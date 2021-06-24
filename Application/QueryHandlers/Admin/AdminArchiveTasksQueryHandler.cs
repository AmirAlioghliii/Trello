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
    public class AdminArchiveTasksQueryHandler : IRequestHandler<AdminArchiveTasksQuery, IEnumerable<UserTask>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;


        public AdminArchiveTasksQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<UserTask>> Handle(AdminArchiveTasksQuery request, CancellationToken cancellationToken)
        {
          return  await _unitOfWork.AdminRepository.GetArchiveTasks(_accessor.GetUserId());
        }
    }
}
