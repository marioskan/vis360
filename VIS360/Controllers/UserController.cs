using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VIS360.Core.Entities;
using VIS360.Core.Interfaces;
using VIS360.Core.ViewModels;

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

        /// <summary>  
        /// Register User  (User)
        /// </summary>
        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(User modelUser)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)202, "Invalid Model");
            }
            var user = await _user.GetUserByEmail(modelUser.Email);
            if (user != null)
            {
                return Content((HttpStatusCode)201, "User already exists");
            }           
            var result = await _user.RegisterUser(modelUser);
            if (result == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)200, "User created successfully");
            }
            return Content((HttpStatusCode)203, "User register failed");
        }

        /// <summary>  
        /// Check user credentials Login  (User)
        /// </summary>
        [HttpPost]
        [Route("Login")]
        public async Task<IHttpActionResult> Login(User userModel)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)202, "Invalid Model");
            }

            var user = await _user.SearchUser(userModel);
            if (user == null)
            {
                return Content((HttpStatusCode)202, "Wrong credentials or user doesn't exist.");
            }
            return Content((HttpStatusCode)205, "User successfully logged in!");
        }

        /// <summary>  
        /// Returns user object based on ID (int id)
        /// </summary>
        [HttpGet]
        [Route("GetUser")]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            var user = await  _user.ReturnUser(id);
            return Ok(user);
        }

        /// <summary>  
        /// Add basic info  (UserInfo)
        /// </summary>
        [HttpPost]
        [Route("BasicInfo")]
        public async Task<IHttpActionResult> BasicInfo(UserInfo userModel)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)202, "Invalid Model");
            }

            var user = await _user.GetUserByEmail(userModel.Email);
            if (user == null)
            {
                return Content((HttpStatusCode)206, "No user exists with that email.");
            }
            userModel.User = user;
            var basicinfo = await _user.AddUserBasicInfo(userModel);
            if (basicinfo == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)207, "Added Basic Info successfully.");
            }
            return Content((HttpStatusCode)208, "Basic info add failed.");
        }

        /// <summary>  
        /// Add demographic info  (Demographic, string email)
        /// </summary>
        //[HttpPost]
        //[Route("DONOTUSE")]
        //public async Task<IHttpActionResult> DemographicInfo(Demographic demographic,string email)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Content((HttpStatusCode)202, "Invalid Model");
        //    }
        //    var user = await _user.GetUserByEmail(email);
        //    if (user == null)
        //    {
        //        return Content((HttpStatusCode)209, "No user exists with that email.");
        //    }
        //    demographic.User = user;
        //    var demo = await _user.AddDemographicInfo(demographic);
        //    if (demo == HttpStatusCode.Accepted)
        //    {
        //        return Content((HttpStatusCode)210, "Added Demographic Info successfully.");
        //    }
        //    return Content((HttpStatusCode)211, "Demographic info add failed.");
        //}

        [HttpPost]
        [Route("AddOtherMember")]
        public async Task<IHttpActionResult> AddOtherMember(OtherMember member)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)202, "Invalid Model");
            }
            var result = await _user.AddOtherMember(member);
            if (result == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)209, "successfully");
            }
            return Content((HttpStatusCode)211, "Member add failed.");
        }

        [HttpPost]
        [Route("DemographicWithID")]
        public async Task<IHttpActionResult> DemographicInfoWithID(DemographicIndustryRoomateVM demographic, int ID)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)202, "Invalid Model");
            }
            var user = await _user.ReturnUser(ID);
            if (user == null)
            {
                return Content((HttpStatusCode)212, "No user exists with that email.");
            }
            demographic.User = user;
            var demo = await _user.AddDemographicInfo(demographic);
            //var returned = await _user.ReturnDemo(user);
            var demoMore = await _user.AddRelInd(demographic.RoomateRelations, demographic.Industries,demo);
            if (demoMore == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)213, "Added Demographic Info successfully.");
            }
            return Content((HttpStatusCode)214, "Demographic info add failed.");
        }

        /// <summary>  
        /// Returns user id only base on email  (string email)
        /// </summary>
        [HttpGet]
        [Route("UserID")]
        public async Task<IHttpActionResult> GetUserID(string email)
        {
            if (email == null)
            {
                return Content((HttpStatusCode)202, "Email cannot be empty");
            }
            var user = await _user.GetUserByEmail(email);
            if (user == null)
            {
                return Content((HttpStatusCode)214, "No user exists with that email.");
            }
            return Ok(user.ID);
        }
    }
}
