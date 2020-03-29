using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIS360.Core.Interfaces;

namespace VIS360.Controllers
{
    [RoutePrefix("api/Disease")]
    public class CovidController : ApiController
    {
        private IUserService _user { get; set; }

        public CovidController(IUserService user)
        {
            _user = user;
        }


    }
}
