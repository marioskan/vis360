using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VIS360.Core.Entities;

namespace VIS360.Core.Interfaces
{
    public interface IUserService
    {
        Task<HttpStatusCode> RegisterUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> SearchUser(User userModel);
    }
}
