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
    public class ApplicantResumeController : ControllerBase
    {
        private readonly ApplicantResumeLogic _logic;

        public ApplicantResumeController()
        {
            var repo = new EFGenericRepository<ApplicantResumePoco>();
            _logic = new ApplicantResumeLogic(repo);
        }

        [HttpGet]
        [Route("applicantresume/{id}")]
        public ActionResult GetApplicantResume(Guid id)
        {
            ApplicantResumePoco poco = _logic.Get(id);
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
        [Route("applicantresume")]
        public ActionResult GetAllApplicantResumes()
        {
            var applicantresumes = _logic.GetAll();
            if (applicantresumes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(applicantresumes);
            }
        }

        [HttpPost]
        [Route("applicantresume")]
        public ActionResult PostApplicantResume(
            [FromBody]ApplicantResumePoco[] applicantresumepocos)
        {
            _logic.Add(applicantresumepocos);
            return Ok();
        }

        [HttpPut]
        [Route("applicantresume")]
        public ActionResult PutApplicantResume(
            [FromBody]ApplicantResumePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("applicantresume")]
        public ActionResult DeleteApplicantResume(
            [FromBody]ApplicantResumePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

    }
}