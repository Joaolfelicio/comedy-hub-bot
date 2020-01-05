using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComedyHub.Core.Components.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> ProcessMeme()
        {
            try
            {
                await _memeOrchestrator.Process();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetMeme")]
        public async Task<IActionResult> GetMeme()
        {
            var meme = await _memeProcessor.ProcessMeme();

            if (meme == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(meme);
        }
    }
}