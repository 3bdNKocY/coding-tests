using API.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ControlController : ControllerBase
    {
        [HttpPost("UpdatePosition")]
        public Task<IActionResult> UpdatePosition([FromQuery] Command command)
        {
            throw new NotImplementedException();
        }
    }
}
