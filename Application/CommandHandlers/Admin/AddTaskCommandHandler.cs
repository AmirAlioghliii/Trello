using Application.Commands.Admin;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Admin
{
    class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, int>
    {
        public Task<int> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
