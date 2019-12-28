using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComedyHub.Core.Components.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComedyHub.Host.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MemesController : Controller
    {
        readonly IMemeOrchestrator _memeOrchestrator;
        private readonly IMemeProcessor _memeProcessor;

        public MemesController(IMemeOrchestrator memeOrchestrator,
                               IMemeProcessor memeProcessor)
        {
            _memeOrchestrator = memeOrchestrator;
            _memeProcessor = memeProcessor;
        }

        [HttpGet]
        public void ProcessMeme()
        {
            _memeOrchestrator.Process();
        }

        [HttpGet("GetMeme")]
        public async Task<IActionResult> GetMeme()
        {
            var meme = await _memeProcessor.ProcessMeme();

            return Ok(meme);
        }
    }
}