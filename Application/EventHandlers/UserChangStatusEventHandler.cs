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
    public class UserChangStatusEventHandler : INotificationHandler<UserChangeStatusEvent>
    {
        private readonly ISendMessage _sendMessage;

        public UserChangStatusEventHandler(ISendMessage sendMessage)
        {
            _sendMessage = sendMessage;
        }

        public async Task Handle(UserChangeStatusEvent notification, CancellationToken cancellationToken)
        {
            await _sendMessage.SendMessageToClient(notification.ConnectionId, "Task Done");
        }
    }
}
