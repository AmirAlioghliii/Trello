using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Models;

namespace Infra.Services
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByEmailAsync(string email);

    }
}
