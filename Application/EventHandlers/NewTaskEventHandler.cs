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
    public class NewTaskEventHandler : INotificationHandler<NewTaskEvent>
    {
        private readonly ISendMessage _sendMessage;

        public NewTaskEventHandler(ISendMessage sendMessage)
        {
            _sendMessage = sendMessage;
        }

        public async Task Handle(NewTaskEvent notification, CancellationToken cancellationToken)
        {
            await _sendMessage.SendMessageToClient(notification.ConnectionId, "Task Created");
        }
    }
}
