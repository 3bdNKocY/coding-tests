using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ControlController : ControllerBase
    {
        [HttpPost("UpdatePosition")]
        public Task<IActionResult> UpdatePosition([FromQuery] char direction)
        {
            throw new NotImplementedException();
        }
    }
}
