using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VIS360.Core.Entities;
using VIS360.Core.Interfaces;
using VIS360.Infrastructure;

namespace VIS360.Common.Services
{
    public class UserService : IUserService
    {
        public Context _context { get; set; }

        public UserService(Context context)
        {
            _context = context;
        }

        public async Task<HttpStatusCode> RegisterUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email).SingleOrDefaultAsync();
            return user;
        }
    }
}
