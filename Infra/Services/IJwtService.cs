using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trello_.Models;

namespace Trello_.Services
{
    public interface IJwtService
    {
        Task<string> GetTokenAsync(ApplicationUser applicationUser);
    }
}
