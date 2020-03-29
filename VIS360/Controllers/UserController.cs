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

        [HttpPost]
        [Route("Login")]
        public async Task<IHttpActionResult> Login(User userModel)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)600, "Invalid Model");
            }

            var user = await _user.SearchUser(userModel);
            if (user == null)
            {
                return Content((HttpStatusCode)604, "Wrong credentials or user doesn't exist.");
            }
            return Content((HttpStatusCode)605, "User successfully logged in!.!");
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            var user = await  _user.ReturnUser(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("BasicInfo")]
        public async Task<IHttpActionResult> BasicInfo(UserInfo userModel)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)600, "Invalid Model");
            }

            var user = await _user.GetUserByEmail(userModel.Email);
            if (user == null)
            {
                return Content((HttpStatusCode)607, "No user exists with that email.");
            }
            userModel.User = user;
            var basicinfo = await _user.AddUserBasicInfo(userModel);
            if (basicinfo == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)606, "Added Basic Info.");
            }
            return Content((HttpStatusCode)607, "Basic info add failed.");
        }

        [HttpPost]
        [Route("Demographic")]
        public async Task<IHttpActionResult> DemographicInfo(Demographic demographic,string email)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)600, "Invalid Model");
            }
            var user = await _user.GetUserByEmail(email);
            if (user == null)
            {
                return Content((HttpStatusCode)607, "No user exists with that email.");
            }
            demographic.User = user;
            var demo = await _user.AddDemographicInfo(demographic);
            if (demo == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)606, "Added Demographic Info.");
            }
            return Content((HttpStatusCode)607, "Demographic info add failed.");
        }

        [HttpGet]
        [Route("UserID")]
        public async Task<IHttpActionResult> GetUserID(string email)
        {
            if (email == null)
            {
                return Content((HttpStatusCode)608, "Email cannot be empty");
            }
            var user = await _user.GetUserByEmail(email);
            if (user == null)
            {
                return Content((HttpStatusCode)607, "No user exists with that email.");
            }
            return Ok(user.ID);
        }
    }
}
