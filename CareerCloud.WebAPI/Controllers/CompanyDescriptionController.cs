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
    public class CompanyDescriptionController : ControllerBase
    {
        private readonly CompanyDescriptionLogic _logic;

        public CompanyDescriptionController()
        {
            var repo = new EFGenericRepository<CompanyDescriptionPoco>();
            _logic = new CompanyDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("companydescription/{id}")]
        public ActionResult GetCompanyDescription(Guid id)
        {
            CompanyDescriptionPoco poco = _logic.Get(id);
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
        [Route("companydescription")]
        public ActionResult GetAllCompanyDescriptions()
        {
            var companyDescriptions = _logic.GetAll();
            if (companyDescriptions == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(companyDescriptions);
            }
        }

        [HttpPost]
        [Route("companydescription")]
        public ActionResult PostCompanyDescription(
            [FromBody]CompanyDescriptionPoco[] companyDescriptionpocos)
        {
            _logic.Add(companyDescriptionpocos);
            return Ok();
        }

        [HttpPut]
        [Route("companydescription")]
        public ActionResult PutCompanyDescription(
            [FromBody]CompanyDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("companydescription")]
        public ActionResult DeleteCompanyDescription(
            [FromBody]CompanyDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}