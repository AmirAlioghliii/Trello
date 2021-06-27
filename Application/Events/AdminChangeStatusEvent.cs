using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events
{
    public class AdminChangeStatusEvent:INotification
    {
        public string ConnectionId { get; set; }
        public string Message { get; set; }
    }
}
