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
    public class ApplicantWorkHistoryController : ControllerBase
    {
        private readonly ApplicantWorkHistoryLogic _logic;

        public ApplicantWorkHistoryController()
        {
            var repo = new EFGenericRepository<ApplicantWorkHistoryPoco>();
            _logic = new ApplicantWorkHistoryLogic(repo);
        }

        [HttpGet]
        [Route("applicantworkhistory/{id}")]
        public ActionResult GetApplicantWorkHistory(Guid id)
        {
            ApplicantWorkHistoryPoco poco = _logic.Get(id);
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
        [Route("applicantworkhistory")]
        public ActionResult GetAllApplicantWorkHistory()
        {
            var applicantworkhistory = _logic.GetAll();
            if (applicantworkhistory == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(applicantworkhistory);
            }
        }

        [HttpPost]
        [Route("applicantworkhistory")]
        public ActionResult PostApplicantWorkHistory(
            [FromBody]ApplicantWorkHistoryPoco[] applicantWorkHistoryPocos)
        {
            _logic.Add(applicantWorkHistoryPocos);
            return Ok();
        }

        [HttpPut]
        [Route("applicantworkhistory")]
        public ActionResult PutApplicantWorkHistory(
            [FromBody]ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("applicantworkhistory")]
        public ActionResult DeleteApplicantWorkHistory(
            [FromBody]ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}