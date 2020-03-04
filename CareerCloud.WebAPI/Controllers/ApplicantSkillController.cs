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
    public class ApplicantSkillController : ControllerBase
    {
        private readonly ApplicantSkillLogic _logic;

        public ApplicantSkillController()
        {
            var repo = new EFGenericRepository<ApplicantSkillPoco>();
            _logic = new ApplicantSkillLogic(repo);
        }

        [HttpGet]
        [Route("applicantskill/{id}")]
        public ActionResult GetApplicantSkill(Guid id)
        {
            ApplicantSkillPoco poco = _logic.Get(id);
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
        [Route("applicantskill")]
        public ActionResult GetAllApplicantSkills()
        {
            var applicantskills = _logic.GetAll();
            if (applicantskills == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(applicantskills);
            }
        }

        [HttpPost]
        [Route("applicantskill")]
        public ActionResult PostApplicantSkill(
            [FromBody]ApplicantSkillPoco[] applicantskillpocos)
        {
            _logic.Add(applicantskillpocos);
            return Ok();
        }

        [HttpPut]
        [Route("applicantskill")]
        public ActionResult PutApplicantSkill(
            [FromBody]ApplicantSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("applicantskill")]
        public ActionResult DeleteApplicantSkill(
            [FromBody]ApplicantSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}