using Application.Queries.Customers;
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

namespace Application.QueryHandlers.Customers
{
    public class CustomerGetAllQueryHandler : IRequestHandler<CustomrGetAllQuery, IEnumerable<UserTask>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;

        public CustomerGetAllQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserTask>> Handle(CustomrGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CustomerRepository.GetAllTasks(_accessor.GetUserId(),request.CategoryId);
        }
    }
}
