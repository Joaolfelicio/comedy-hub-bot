// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="RedditComponent.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary> Fetchs, mapp and filters the reddit model</summary>
// ***********************************************************************
using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components
{
    /// <summary>
    /// Class RedditComponent.
    /// Implements the <see cref="ComedyHub.Core.Components.Contracts.IRedditComponent" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Components.Contracts.IRedditComponent" />
    public class RedditComponent : IRedditComponent
    {
        /// <summary>
        /// The reddit fetch service
        /// </summary>
        private readonly IRedditFetchService _redditFetchService;
        /// <summary>
        /// The reddit mapper service
        /// </summary>
        private readonly IRedditMapperService _redditMapperService;
        /// <summary>
        /// The filter service
        /// </summary>
        private readonly IFilterService _filterService;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<RedditComponent> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedditComponent"/> class.
        /// </summary>
        /// <param name="redditFetchService">The reddit fetch service.</param>
        /// <param name="redditMapperService">The reddit mapper service.</param>
        /// <param name="filterService">The filter service.</param>
        /// <param name="logger">The logger.</param>
        public RedditComponent(IRedditFetchService redditFetchService,
                               IRedditMapperService redditMapperService,
                               IFilterService filterService,
                               ILogger<RedditComponent> logger)
        {
            _redditFetchService = redditFetchService;
            _redditMapperService = redditMapperService;
            _filterService = filterService;
            _logger = logger;
        }
        /// <summary>
        /// Gets the reddit meme.
        /// </summary>
        /// <returns>The MemeModel</returns>
        public async Task<MemeModel> GetRedditMeme()
        {
            var redditMemes = _redditFetchService.GetRedditModelMeme();

            _logger.LogInformation("Received reddit memes");

            var mappedMemes = _redditMapperService.RedditModelToMemes(redditMemes);

            _logger.LogInformation("Mapped to memes models");

            var filteredMeme = await _filterService.FilterMemes(mappedMemes);

            _logger.LogInformation("Filtered memes to meme");

            return filteredMeme;
        }
    }
}
