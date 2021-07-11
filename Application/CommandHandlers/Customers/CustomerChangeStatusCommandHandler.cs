using Application.Commands.Customers;
using Application.Events;
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
        private readonly IMediator _mediator;

        public CustomerChangeStatusCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CustomerChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var task=await _unitOfWork.UserTaskRepository.GetTaskById(request.TaskId);
            task.Status="Done";
            //await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.UserTaskRepository.UpdateTaskAsnc(task);
            var user =await _unitOfWork.UserRepository.GetUserById(task.AdminId);
            await _mediator.Publish(new UserChangeStatusEvent() { ConnectionId = user.ConnectionId });
            return request.TaskId;
        }
    }
}
