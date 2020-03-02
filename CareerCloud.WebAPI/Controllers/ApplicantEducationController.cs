using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using CareerCloud.EntityFrameworkDataAccess;
using Microsoft.AspNetCore.Mvc;
using CareerCloud.Pocos;

namespace CareerCloud.WebAPI.Controllers
{

    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantEducationController : ControllerBase
    {
        private readonly ApplicantEducationLogic _logic;

        public ApplicantEducationController()
        {
            var repo = new EFGenericRepository<ApplicantEducationPoco>();
            _logic = new ApplicantEducationLogic(repo);
        }

        [HttpGet]
        [Route("education/{id}")]
        public ActionResult GetApplicantEducation(Guid id)
        {
            ApplicantEducationPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(poco);
            }
        }

        [HttpPost]
        [Route("Education")]
        public ActionResult PostApplicantEducation(
            [FromBody]ApplicantEducationPoco[] appEduPocos)
        {
            _logic.Add(appEduPocos);
            return Ok();
        }
    }
}