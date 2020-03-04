using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantJobApplicationController : ControllerBase
    {
        private readonly ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationController()
        {
            var repo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            _logic = new ApplicantJobApplicationLogic(repo);
        }

        [HttpGet]
        [Route("applicantjobapplication/{id}")]
        public ActionResult GetApplicantJobApplication(Guid id)
        {
            ApplicantJobApplicationPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(poco);
            }
        }

        [HttpGet]
        [Route("applicantjobapplication")]
        public ActionResult GetAllApplicantJobApplication()
        {
            var applicantjobapplications = _logic.GetAll();
            if (applicantjobapplications == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(applicantjobapplications);
            }
        }

        [HttpPost]
        [Route("applicantjobapplication")]
        public ActionResult PostApplicantJobApplication(
            [FromBody]ApplicantJobApplicationPoco[] appjobapplicationPocos)
        {
            _logic.Add(appjobapplicationPocos);
            return Ok();
        }

        [HttpPut]
        [Route("applicantjobapplication")]
        public ActionResult PutApplicantJobApplication(
            [FromBody]ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("applicantjobapplication")]
        public ActionResult DeleteApplicantJobApplication(
            [FromBody]ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

    }
}