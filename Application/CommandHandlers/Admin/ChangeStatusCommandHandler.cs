using Application.Commands.Admin;
using Application.Events;
using Infra.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Admin
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, int>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMediator _mediator;
        
        public ChangeStatusCommandHandler(IUnitOfWork unitofwork, IMediator mediator)
        {
            _mediator = mediator;
            _unitofwork = unitofwork;
        }

        public async Task<int> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var task=await _unitofwork.UserTaskRepository.GetTaskById(request.Id);
            task.Status = request.Status;
            task.TaskTime = DateTime.Now + TimeSpan.FromHours(6);
            await _unitofwork.UserTaskRepository.UpdateTaskAsnc(task);
            //await _unitofwork.SaveChangesAsync();

            var user =await _unitofwork.UserRepository.GetUserById(task.UserId);
            await _mediator.Publish(new AdminChangeStatusEvent() { ConnectionId = user.ConnectionId, Message = request.Status });

            return request.Id;

            
        }
    }
}
