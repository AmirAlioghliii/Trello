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
    public class AlarmEventHandler : INotificationHandler<AlarmEvent>
    {
        private readonly ISendMessage _sendMessage;

        public AlarmEventHandler(ISendMessage sendMessage)
        {
            _sendMessage = sendMessage;
        }


        public async Task Handle(AlarmEvent notification, CancellationToken cancellationToken)
        {
            await _sendMessage.SendMessageToClient(notification.ConecctionId, notification.Message);
        }
    }
}
