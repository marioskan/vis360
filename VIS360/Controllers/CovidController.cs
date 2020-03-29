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
    [RoutePrefix("api/Disease")]
    public class CovidController : ApiController
    {
        private IUserService _user { get; set; }

        public CovidController(IUserService user)
        {
            _user = user;
        }

        [HttpPost]
        [Route("BasicInfo")]
        public async Task<IHttpActionResult> BasicInfo(CovidStatus status)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)600, "Invalid Model");
            }

            var covidStatus = await _user.AddVirusStatus(status);
            if (covidStatus == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)608, "Added Covid Status");
            }
            return Content((HttpStatusCode)606, "Covid Status add failed");
        }

        [HttpPost]
        [Route("Statement")]
        public async Task<IHttpActionResult> DiseaseStatement(DiseaseStatement diseaseStatement)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)600, "Invalid Model");
            }

            var disease = await _user.AddDiseaseStatement(diseaseStatement);
            if (disease == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)608, "Added Disease Statement");
            }
            return Content((HttpStatusCode)606, "Disease Statement add failed");
        }
    }
}
