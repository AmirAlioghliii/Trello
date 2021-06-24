using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Trello_.Data;
using Trello_.Extensions;

namespace Trello.Api.Hubs
{
    public class SendMessageHub:Hub
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ApplicationDbContext _context;
        string lastconnectionId;

        public SendMessageHub(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        
        public async Task SendmessageToClient(string signalRConnectionId, string message)
        {
            await Clients.User(signalRConnectionId).SendAsync("SendMessage", message);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async override Task OnConnectedAsync()
        {
            lastconnectionId = Context.ConnectionId;
            var user= await _context.ApplicationUsers.SingleOrDefaultAsync(u => u.Id == _accessor.GetUserId());
            user.ConnectionId = lastconnectionId;
            await _context.SaveChangesAsync();


        }

    }
}
