using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trello_.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string ConnectionId { get; set; }
    }
}
