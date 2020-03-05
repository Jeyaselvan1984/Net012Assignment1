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
    public class SecurityLoginController : ControllerBase
    {
        private readonly SecurityLoginLogic _logic;
        public SecurityLoginController()
        {
            var repo = new EFGenericRepository<SecurityLoginPoco>();
            _logic = new SecurityLoginLogic(repo);
        }

        [HttpGet]
        [Route("securitylogin/{id}")]
        public ActionResult GetSecurityLogin(Guid id)
        {
            SecurityLoginPoco poco = _logic.Get(id);
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
        [Route("securitylogin")]
        public ActionResult GetSecurityLogins()
        {
            var securityLogins = _logic.GetAll();
            if (securityLogins == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(securityLogins);
            }
        }

        [HttpPost]
        [Route("securitylogin")]
        public ActionResult PostSecurityLogin(
            [FromBody]SecurityLoginPoco[] securityloginPoco)
        {
            _logic.Add(securityloginPoco);
            return Ok();
        }

        [HttpPut]
        [Route("securitylogin")]
        public ActionResult PutSecurityLogin(
            [FromBody]SecurityLoginPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("securitylogin")]
        public ActionResult DeleteSecurityLogin(
            [FromBody]SecurityLoginPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}