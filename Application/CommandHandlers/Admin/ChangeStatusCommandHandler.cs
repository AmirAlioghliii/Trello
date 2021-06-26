using Application.Commands.Admin;
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

        
        public ChangeStatusCommandHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<int> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            await _unitofwork.AdminRepository.ChangeTaskStatus(request.Id, request.Status);
            await _unitofwork.SaveChangesAsync();
            return request.Id;

            
        }
    }
}
