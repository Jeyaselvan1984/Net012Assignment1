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
    public class CompanyJobSkillController : ControllerBase
    {
        private readonly CompanyJobSkillLogic _logic;
        public CompanyJobSkillController()
        {
            var repo = new EFGenericRepository<CompanyJobSkillPoco>();
            _logic = new CompanyJobSkillLogic(repo);
        }

        [HttpGet]
        [Route("companyjobskill/{id}")]
        public ActionResult GetCompanyJobSkill(Guid id)
        {
            CompanyJobSkillPoco poco = _logic.Get(id);
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
        [Route("companyjobskill")]
        public ActionResult GetAllCompanyJobSkills()
        {
            var copmanyJobSkills = _logic.GetAll();
            if (copmanyJobSkills == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(copmanyJobSkills);
            }
        }

        [HttpPost]
        [Route("companyjobskill")]
        public ActionResult PostCompanyJobSkill(
            [FromBody]CompanyJobSkillPoco[] copmanyJobSkillsPoco)
        {
            _logic.Add(copmanyJobSkillsPoco);
            return Ok();
        }

        [HttpPut]
        [Route("companyjobskill")]
        public ActionResult PutCompanyJobSkill(
            [FromBody]CompanyJobSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("companyjobskill")]
        public ActionResult DeleteCompanyJobSkill(
            [FromBody]CompanyJobSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}