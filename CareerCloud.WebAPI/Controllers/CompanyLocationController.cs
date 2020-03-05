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
    public class CompanyLocationController : ControllerBase
    {
        private readonly CompanyLocationLogic _logic;
        public CompanyLocationController()
        {
            var repo = new EFGenericRepository<CompanyLocationPoco>();
            _logic = new CompanyLocationLogic(repo);
        }

        [HttpGet]
        [Route("companylocation/{id}")]
        public ActionResult GetCompanyLocation(Guid id)
        {
            CompanyLocationPoco poco = _logic.Get(id);
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
        [Route("companylocation")]
        public ActionResult GetAllCompanyLocations()
        {
            var companyLocations = _logic.GetAll();
            if (companyLocations == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(companyLocations);
            }
        }

        [HttpPost]
        [Route("companylocation")]
        public ActionResult PostCompanyLocation(
            [FromBody]CompanyLocationPoco[] companyLocationsPoco)
        {
            _logic.Add(companyLocationsPoco);
            return Ok();
        }

        [HttpPut]
        [Route("companylocation")]
        public ActionResult PutCompanyLocation(
            [FromBody]CompanyLocationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("companylocation")]
        public ActionResult DeleteCompanyLocation(
            [FromBody]CompanyLocationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}