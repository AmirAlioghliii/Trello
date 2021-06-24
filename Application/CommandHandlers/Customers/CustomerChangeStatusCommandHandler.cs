using Application.Commands.Customers;
using Infra.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Customers
{
    public class CustomerChangeStatusCommandHandler : IRequestHandler<CustomerChangeStatusCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerChangeStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CustomerChangeStatusCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.CustomerRepository.ChangeTaskStatus(request.TaskId, request.Status);
            await _unitOfWork.SaveChangesAsync();
            return request.TaskId;
        }
    }
}
