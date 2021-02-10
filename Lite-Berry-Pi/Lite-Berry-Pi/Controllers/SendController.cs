using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        // POST: liteberrypi
        [HttpGet("/liteberrypi")]
        public async Task SendLiteBerry(string designCoords)
        {

        }
    }
}
