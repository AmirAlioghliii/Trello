using Application.Hubs;
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
    public class SendMessageHub:Hub,ISendMessage
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ApplicationDbContext _context;

        public SendMessageHub(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async override Task OnConnectedAsync()
        {
            var user= await _context.ApplicationUsers.SingleOrDefaultAsync(u => u.Id == _accessor.GetUserId());
            user.ConnectionId = Context.ConnectionId;
            await _context.SaveChangesAsync();
        }

        public async Task SendMessageToClient(string connectionId, string message)
        {
            await Clients.User(connectionId).SendAsync("SendMessage", message);
        }
    }
}
