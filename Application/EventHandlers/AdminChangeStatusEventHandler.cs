using Application.Events;
using Application.Hubs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EventHandlers
{
    public class AdminChangeStatusEventHandler : INotificationHandler<AdminChangeStatusEvent>
    {
        private readonly ISendMessage _sendMessage;

        public AdminChangeStatusEventHandler(ISendMessage sendMessage)
        {
            _sendMessage = sendMessage;
        }

        public async Task Handle(AdminChangeStatusEvent notification, CancellationToken cancellationToken)
        {


            await _sendMessage.SendMessageToClient(notification.ConnectionId, notification.Message);
        }
    }
}
