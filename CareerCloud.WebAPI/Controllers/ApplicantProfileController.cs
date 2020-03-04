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
    public class ApplicantProfileController : ControllerBase
    {
        private readonly ApplicantProfileLogic _logic;

        public ApplicantProfileController()
        {
            var repo = new EFGenericRepository<ApplicantProfilePoco>();
            _logic = new ApplicantProfileLogic(repo);
        }

        [HttpGet]
        [Route("applicantprofile/{id}")]
        public ActionResult GetApplicantProfile(Guid id)
        {
            ApplicantProfilePoco poco = _logic.Get(id);
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
        [Route("applicantprofile")]
        public ActionResult GetAllApplicantProfiles()
        {
            var applicantprofiles = _logic.GetAll();
            if (applicantprofiles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(applicantprofiles);
            }
        }

        [HttpPost]
        [Route("applicantprofile")]
        public ActionResult PostApplicantProfile(
            [FromBody]ApplicantProfilePoco[] applicantprofilepocos)
        {
            _logic.Add(applicantprofilepocos);
            return Ok();
        }

        [HttpPut]
        [Route("applicantprofile")]
        public ActionResult PutApplicantProfile(
            [FromBody]ApplicantProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("applicantprofile")]
        public ActionResult DeleteApplicantProfile(
            [FromBody]ApplicantProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}