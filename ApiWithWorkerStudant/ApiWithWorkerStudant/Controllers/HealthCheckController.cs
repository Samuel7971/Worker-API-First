using ApiWithWorkerRespository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiWithWorkerStudant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : Controller
    {
        [HttpGet]
        public string Get()
        {
            var date = DateTime.Now;
            var retorno = string.Format($" Data e hora: {date}");
            return retorno;
        }

        [HttpPost("SetMessage")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public IActionResult SetCommand(string message, [FromServices] ICommandRepository commandRepository)
        {
            commandRepository.SetMessage(message);
            return Ok(commandRepository.GetMessage());
        }
    }
}
