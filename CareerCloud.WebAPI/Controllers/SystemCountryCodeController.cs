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
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemCountryCodeController : ControllerBase
    {
        private readonly SystemCountryCodeLogic _logic;
        public SystemCountryCodeController()
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>();
            _logic = new SystemCountryCodeLogic(repo);
        }

        [HttpGet]
        [Route("systemcountrycode/{code}")]
        public ActionResult GetSystemCountryCode(string code)
        {
            SystemCountryCodePoco poco = _logic.Get(code);
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
        [Route("systemcountrycode")]
        public ActionResult GetAllSystemCountryCode()
        {
            var systemcountrycode = _logic.GetAll();
            if (systemcountrycode == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(systemcountrycode);
            }
        }

        [HttpPost]
        [Route("systemcountrycode")]
        public ActionResult PostSystemCountryCode(
            [FromBody]SystemCountryCodePoco[] systemcountrycodepoco)
        {
            _logic.Add(systemcountrycodepoco);
            return Ok();
        }

        [HttpPut]
        [Route("systemcountrycode")]
        public ActionResult PutSystemCountryCode(
            [FromBody]SystemCountryCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("systemcountrycode")]
        public ActionResult DeleteSystemCountryCode(
            [FromBody]SystemCountryCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}