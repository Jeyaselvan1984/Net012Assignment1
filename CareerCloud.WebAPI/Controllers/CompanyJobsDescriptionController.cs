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
    public class CompanyJobsDescriptionController : ControllerBase
    {
        private readonly CompanyJobDescriptionLogic _logic;
        public CompanyJobsDescriptionController()
        {
            var repo = new EFGenericRepository<CompanyJobDescriptionPoco>();
            _logic = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("companyjobdescription/{id}")]
        public ActionResult GetCompanyJobsDescription(Guid id)
        {
            CompanyJobDescriptionPoco poco = _logic.Get(id);
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
        [Route("companyjobdescription")]
        public ActionResult GetAllCompanyJobDescriptions()
        {
            var copmanyJobDescriptions = _logic.GetAll();
            if (copmanyJobDescriptions == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(copmanyJobDescriptions);
            }
        }

        [HttpPost]
        [Route("companyjobdescription")]
        public ActionResult PostCompanyJobsDescription(
            [FromBody]CompanyJobDescriptionPoco[] compJobDescriptionPocos)
        {
            _logic.Add(compJobDescriptionPocos);
            return Ok();
        }

        [HttpPut]
        [Route("companyjobdescription")]
        public ActionResult PutCompanyJobsDescription(
            [FromBody]CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("companyjobdescription")]
        public ActionResult DeleteCompanyJobsDescription(
            [FromBody]CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}