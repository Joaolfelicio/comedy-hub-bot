// ***********************************************************************
// Assembly         : ComedyHub.Host
// Author           : Joaolfelicio
// Created          : 12-27-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="MemesController.cs" company="ComedyHub.Host">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class MemesController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiController]
    [Route("api/[Controller]")]
    public class MemesController : Controller
    {
        /// <summary>
        /// The meme orchestrator
        /// </summary>
        private readonly IMemeOrchestrator _memeOrchestrator;
        /// <summary>
        /// The meme processor
        /// </summary>
        private readonly IMemeProcessor _memeProcessor;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<MemesController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemesController"/> class.
        /// </summary>
        /// <param name="memeOrchestrator">The meme orchestrator.</param>
        /// <param name="memeProcessor">The meme processor.</param>
        /// <param name="logger">The logger.</param>
        public MemesController(IMemeOrchestrator memeOrchestrator,
                               IMemeProcessor memeProcessor,
                               ILogger<MemesController> logger)
        {
            _memeOrchestrator = memeOrchestrator;
            _memeProcessor = memeProcessor;
            _logger = logger;
        }

        /// <summary>
        /// Processes the meme.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ProcessMeme()
        {
            try
            {
                _logger.LogInformation("Called ProcessMeme");

                await _memeOrchestrator.Process();

                return Json(new { Status = "Success", Message = "Successfully published meme" });
            }
            catch (Exception ex)
            {
                return Json(new { Status = "Failure", Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the meme as Json.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMeme")]
        public async Task<IActionResult> GetMeme()
        {
            var meme = await _memeProcessor.ProcessMeme();

            if (meme == null)
            {
                return Json(new { Status = "Failure", Message = "Meme is null" });
            }
            return Ok(meme);
        }
    }
}