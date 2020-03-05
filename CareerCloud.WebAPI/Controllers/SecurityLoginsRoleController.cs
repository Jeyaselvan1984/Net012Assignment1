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
[
    Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityLoginsRoleController : ControllerBase
    {
        private readonly SecurityLoginsRoleLogic _logic;
        public SecurityLoginsRoleController()
        {
            var repo = new EFGenericRepository<SecurityLoginsRolePoco>();
            _logic = new SecurityLoginsRoleLogic(repo);
        }

        [HttpGet]
        [Route("securityloginsrole/{id}")]
        public ActionResult GetSecurityLoginsRole(Guid id)
        {
            SecurityLoginsRolePoco poco = _logic.Get(id);
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
        [Route("securityloginsrole")]
        public ActionResult GetAllSecurityLoginsRole()
        {
            var securityloginsrole = _logic.GetAll();
            if (securityloginsrole == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(securityloginsrole);
            }
        }

        [HttpPost]
        [Route("securityloginsrole")]
        public ActionResult PostSecurityLoginsRole(
            [FromBody]SecurityLoginsRolePoco[] securityloginsrolepoco)
        {
            _logic.Add(securityloginsrolepoco);
            return Ok();
        }

        [HttpPut]
        [Route("securityloginsrole")]
        public ActionResult PutSecurityLoginsRole(
            [FromBody]SecurityLoginsRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("securityloginsrole")]
        public ActionResult DeleteSecurityLoginsRole(
            [FromBody]SecurityLoginsRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}