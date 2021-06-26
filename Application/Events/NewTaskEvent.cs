using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events
{
    public class NewTaskEvent:INotification
    {
        public string ConnectionId { get; set; }
    }
}
