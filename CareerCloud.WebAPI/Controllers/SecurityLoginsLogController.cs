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
    public class SecurityLoginsLogController : ControllerBase
    {
        private readonly SecurityLoginsLogLogic _logic;
        public SecurityLoginsLogController()
        {
            var repo = new EFGenericRepository<SecurityLoginsLogPoco>();
            _logic = new SecurityLoginsLogLogic(repo);
        }

        [HttpGet]
        [Route("securityloginslog/{id}")]
        public ActionResult GetSecurityLoginLog(Guid id)
        {
            SecurityLoginsLogPoco poco = _logic.Get(id);
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
        [Route("securityloginslog")]
        public ActionResult GetAllSecurityLoginsLog()
        {
            var securityLoginsLog = _logic.GetAll();
            if (securityLoginsLog == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(securityLoginsLog);
            }
        }

        [HttpPost]
        [Route("securityloginslog")]
        public ActionResult PostSecurityLoginLog(
            [FromBody]SecurityLoginsLogPoco[] securityloginlogsPoco)
        {
            _logic.Add(securityloginlogsPoco);
            return Ok();
        }

        [HttpPut]
        [Route("securityloginslog")]
        public ActionResult PutSecurityLoginLog(
            [FromBody]SecurityLoginsLogPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("securityloginslog")]
        public ActionResult DeleteSecurityLoginLog(
            [FromBody]SecurityLoginsLogPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}