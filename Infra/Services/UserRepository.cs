using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Data;
using Trello_.Models;

namespace Infra.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
           return await _context.ApplicationUsers.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
