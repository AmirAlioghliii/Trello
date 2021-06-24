using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Customers
{
    public class CustomerChangeStatusCommand:IRequest<int>
    {
        public int TaskId{ get; set; }
        public string Status{ get; set; }
    }
}
