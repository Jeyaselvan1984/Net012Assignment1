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
    public class CompanyProfileController : ControllerBase
    {
        private readonly CompanyProfileLogic _logic;
        public CompanyProfileController()
        {
            var repo = new EFGenericRepository<CompanyProfilePoco>();
            _logic = new CompanyProfileLogic(repo);
        }

        [HttpGet]
        [Route("companyprofile/{id}")]
        public ActionResult GetCompanyProfile(Guid id)
        {
            CompanyProfilePoco poco = _logic.Get(id);
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
        [Route("companyprofile")]
        public ActionResult GetAllCompanyProfiles()
        {
            var companyprofiles = _logic.GetAll();
            if (companyprofiles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(companyprofiles);
            }
        }

        [HttpPost]
        [Route("companyprofile")]
        public ActionResult PostCompanyProfile(
            [FromBody]CompanyProfilePoco[] companyProfilesPoco)
        {
            _logic.Add(companyProfilesPoco);
            return Ok();
        }

        [HttpPut]
        [Route("companyprofile")]
        public ActionResult PutCompanyProfile(
            [FromBody]CompanyProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("companyprofile")]
        public ActionResult DeleteCompanyProfile(
            [FromBody]CompanyProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}