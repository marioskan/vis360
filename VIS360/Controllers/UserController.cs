using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web.Http;
using Serilog;
using Serilog.Sinks.Slack;
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
                //var log = new LoggerConfiguration()
                //    .WriteTo.Slack("https://hooks.slack.com/services/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")
                //    .CreateLogger();
                //log.Information("User: "+modelUser.Email +" created");
                return Content((HttpStatusCode)200, "User created successfully");
            }
            return Content((HttpStatusCode)203, "User register failed");
        }



        [HttpGet]
        [Route("GetUser")]
        public async Task<IHttpActionResult> GetUser(string ud)
        {
            var user = await _user.ReturnUser(ud);
            return Ok(user);
        }

        [HttpPost]
        [Route("BasicInfo")]
        public async Task<IHttpActionResult> BasicInfo(UserInfo userModel)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)202, "Invalid Model");
            }

            var user = await _user.GetUserByID(userModel.UserID);
            if (user == null)
            {
                return Content((HttpStatusCode)201, "No user exists with that email.");
            }
            userModel.User = user;
            var basicinfo = await _user.AddUserBasicInfo(userModel);
            if (basicinfo == HttpStatusCode.Accepted)
            {               
                return Content((HttpStatusCode)200, "Added Basic Info successfully.");
            }
            return Content((HttpStatusCode)201, "Basic info add failed.");
        }

        

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
                return Content((HttpStatusCode)200, "successfully");
            }
            return Content((HttpStatusCode)201, "Member add failed.");
        }

        [HttpPost]
        [Route("Demographic")]
        public async Task<IHttpActionResult> DemographicInfo(DemographicIndustryRoomateVM demographic)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)202, "Invalid Model");
            }
            var user = await _user.ReturnUser(demographic.UserID);
            if (user == null)
            {
                return Content((HttpStatusCode)201, "No user exists with that email.");
            }
            demographic.User = user;
            var demo = await _user.AddDemographicInfo(demographic);
            //var returned = await _user.ReturnDemo(user);
            var demoMore = await _user.AddRelInd(demographic.RoomateRelations, demographic.Industries,demo);
            if (demoMore == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)200, "Added Demographic Info successfully.");
            }
            return Content((HttpStatusCode)201, "Demographic info add failed.");
        }

        [HttpGet]
        [Route("GetMembers")]
        public async Task<IHttpActionResult> GetMembers(string ID)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)202, "Invalid Model");
            }
            var members = await _user.ReturnMembers(ID);
            return Ok(members);
        }
    }
}
