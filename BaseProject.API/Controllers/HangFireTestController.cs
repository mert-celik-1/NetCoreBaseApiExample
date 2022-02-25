using BaseProject.Services.BackgroundJobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangFireTestController : ControllerBase
    {
        [HttpGet]
        public IActionResult TestHangFire()
        {
            DelayedJobs.DebugOutput();

            return Ok();
        }

    }
}
