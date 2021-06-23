using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Admin
{
    public class AddTaskCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public string AdminId { get; set; }
    }
}
