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
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyJobController : ControllerBase
    {
        private readonly CompanyJobLogic _logic;

        public CompanyJobController()
        {
            var repo = new EFGenericRepository<CompanyJobPoco>();
            _logic = new CompanyJobLogic(repo);
        }

        [HttpGet]
        [Route("companyjobs/{id}")]
        public ActionResult GetCompanyJob(Guid id)
        {
            CompanyJobPoco poco = _logic.Get(id);
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
        [Route("companyjobs")]
        public ActionResult GetAllCompanyJobs()
        {
            var copmanyJobs = _logic.GetAll();
            if (copmanyJobs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(copmanyJobs);
            }
        }

        [HttpPost]
        [Route("companyjobs")]
        public ActionResult PostCompanyJob(
            [FromBody]CompanyJobPoco[] compJobPocos)
        {
            _logic.Add(compJobPocos);
            return Ok();
        }

        [HttpPut]
        [Route("companyjobs")]
        public ActionResult PutCompanyJob(
            [FromBody]CompanyJobPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("companyjobs")]
        public ActionResult DeleteCompanyJob(
            [FromBody]CompanyJobPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

    }
}