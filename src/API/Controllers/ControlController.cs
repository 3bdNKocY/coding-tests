using API.Requests;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ControlController : ControllerBase
    {
        private readonly IControlService _controlService;

        public ControlController(IControlService controlService)
        {
            _controlService = controlService;
        }

        [HttpPost("UpdatePosition")]
        public async Task<IActionResult> UpdatePosition([FromQuery] Command command)
        {
            var newPosition = await _controlService.ProcessCommand(command);

            return Ok(newPosition);
        }
    }
}
