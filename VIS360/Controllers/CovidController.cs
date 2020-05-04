using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.WebPages;
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

        /// <summary>  
        /// Add covid basic info  (CovidStatus)
        /// </summary>
        [HttpPost]
        [Route("BasicInfo")]
        public async Task<IHttpActionResult> BasicInfo(CovidStatus status)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)201, "Invalid Model");
            }

            if (status.UserID == null)
            {
                return Content((HttpStatusCode)201, "Invalid Model");
            }
            var covidStatus = await _user.AddVirusStatus(status);
            if (covidStatus == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)200, "Added Covid Status successfully");
            }
            return Content((HttpStatusCode)202, "Covid Status add failed");
        }

        /// <summary>  
        /// Add disease statement  (DiseaseStatement)
        /// </summary>
        [HttpPost]
        [Route("Statement")]
        public async Task<IHttpActionResult> DiseaseStatement(DiseaseStatement diseaseStatement)
        {
            if (!ModelState.IsValid)
            {
                return Content((HttpStatusCode)202, "Invalid Model");
            }
            else if (diseaseStatement.OtherMemberID == null && diseaseStatement.UserID == null)
            {
                return Content((HttpStatusCode)201, "userid and othermember id cant be both null");
            }
            else if (diseaseStatement.OtherMemberID == 0 || diseaseStatement.UserID.IsEmpty())
            {
                return Content((HttpStatusCode)201, "userid and othermember id cant be both null");
            }
            var disease = await _user.AddDiseaseStatement(diseaseStatement);
            if (disease == HttpStatusCode.Accepted)
            {
                return Content((HttpStatusCode)200, "Added Disease Statement successfully");
            }
            return Content((HttpStatusCode)201, "Disease Statement add failed");
        }
    }
}
