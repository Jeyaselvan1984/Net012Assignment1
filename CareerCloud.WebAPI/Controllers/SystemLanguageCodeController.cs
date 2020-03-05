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
    public class SystemLanguageCodeController : ControllerBase
    {
        private readonly SystemLanguageCodeLogic _logic;
        public SystemLanguageCodeController()
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>();
            _logic = new SystemLanguageCodeLogic(repo);
        }

        [HttpGet]
        [Route("systemlanguagecode/{langId}")]
        public ActionResult GetSystemLanguageCode(string langId)
        {
            SystemLanguageCodePoco poco = _logic.Get(langId);
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
        [Route("systemlanguagecode")]
        public ActionResult GetAllSystemLanguageCode()
        {
            var systemlanguagecode = _logic.GetAll();
            if (systemlanguagecode == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(systemlanguagecode);
            }
        }

        [HttpPost]
        [Route("systemlanguagecode")]
        public ActionResult PostSystemLanguageCode(
            [FromBody]SystemLanguageCodePoco[] systemlanguagecodepoco)
        {
            _logic.Add(systemlanguagecodepoco);
            return Ok();
        }

        [HttpPut]
        [Route("systemlanguagecode")]
        public ActionResult PutSystemLanguageCode(
            [FromBody]SystemLanguageCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("systemlanguagecode")]
        public ActionResult DeleteSystemLanguageCode(
            [FromBody]SystemLanguageCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}