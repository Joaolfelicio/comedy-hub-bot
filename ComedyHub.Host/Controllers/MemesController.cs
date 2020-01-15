using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComedyHub.Core.Components.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Reddit;
using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using Microsoft.Extensions.Logging;

namespace ComedyHub.Host.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MemesController : Controller
    {
        private readonly IMemeOrchestrator _memeOrchestrator;
        private readonly IMemeProcessor _memeProcessor;
        private readonly ILogger<MemesController> _logger;

        public MemesController(IMemeOrchestrator memeOrchestrator,
                               IMemeProcessor memeProcessor,
                               ILogger<MemesController> logger)
        {
            _memeOrchestrator = memeOrchestrator;
            _memeProcessor = memeProcessor;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ProcessMeme()
        {
            try
            {
                _logger.LogInformation("Called ProcessMeme");

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