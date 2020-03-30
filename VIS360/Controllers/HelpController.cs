﻿using System;
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
    [RoutePrefix("api/Help")]
    public class HelpController : ApiController
    {
        private IUserService _user { get; set; }

        public HelpController(IUserService user)
        {
            _user = user;
        }

        /// <summary>  
        /// Add help  (Help)
        /// </summary>
        [HttpPost]
        [Route("Need")]
        public async Task<IHttpActionResult> AddHelp(Help help)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)600, "Invalid Model");
            }

            var _help = await _user.AddHelp(help);
            if (_help == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)608, "Added Help");
            }
            return Content((HttpStatusCode)606, "Help add failed");
        }

        /// <summary>  
        /// Add help offer (HelpOffer)
        /// </summary> 
        [HttpPost]
        [Route("Offer")]
        public async Task<IHttpActionResult> AddHelpOffer(HelpOffer helpOffer)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)600, "Invalid Model");
            }

            var _help = await _user.AddHelpOffer(helpOffer);
            if (_help == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)608, "Added Help offer");
            }
            return Content((HttpStatusCode)606, "Help offer add failed");
        }
    }
}
