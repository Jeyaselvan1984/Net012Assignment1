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

    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityRoleController : ControllerBase
    {
        private readonly SecurityRoleLogic _logic;
        public SecurityRoleController()
        {
            var repo = new EFGenericRepository<SecurityRolePoco>();
            _logic = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("securityrole/{id}")]
        public ActionResult GetSecurityRole(Guid id)
        {
            SecurityRolePoco poco = _logic.Get(id);
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
        [Route("securityrole")]
        public ActionResult GetSecurityRole()
        {
            var securityrole = _logic.GetAll();
            if (securityrole == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(securityrole);
            }
        }

        [HttpPost]
        [Route("securityrole")]
        public ActionResult PostSecurityRole(
            [FromBody]SecurityRolePoco[] securityrolepoco)
        {
            _logic.Add(securityrolepoco);
            return Ok();
        }

        [HttpPut]
        [Route("securityrole")]
        public ActionResult PutSecurityRole(
            [FromBody]SecurityRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("securityrole")]
        public ActionResult DeleteSecurityRole(
            [FromBody]SecurityRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}