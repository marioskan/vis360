using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VIS360.Core.Entities;
using VIS360.Core.Interfaces;

namespace VIS360.Controllers
{
    [RoutePrefix("api/Account")]
    public class UserController : ApiController
    {
        private IUserService _user { get; set; }

        public UserController(IUserService user)
        {
            _user = user;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(User modelUser)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode) 600, "Invalid Model");
            }

            var user = await _user.GetUserByEmail(modelUser.Email);
            if (user != null)
            {
                return Content((HttpStatusCode)601, "User already exists");
            }           
            var result = await _user.RegisterUser(modelUser);
            if (result == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)602, "User created");
            }
            return Content((HttpStatusCode)603, "User register failed");
        }
    }
}
