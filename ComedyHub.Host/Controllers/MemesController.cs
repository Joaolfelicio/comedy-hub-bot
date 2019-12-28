using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComedyHub.Core.Components.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComedyHub.Host.Controllers
{
    [ApiController]
    [Route("api/Memes")]
    public class MemesController : Controller
    {
        readonly IMemeOrchestrator _memeOrchestrator;
        public MemesController(IMemeOrchestrator memeOrchestrator)
        {
            _memeOrchestrator = memeOrchestrator;
        }

        [HttpGet("Process")]
        public void ProcessMeme()
        {
            _memeOrchestrator.Process();
        }
    }
}