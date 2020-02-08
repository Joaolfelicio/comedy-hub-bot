// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-28-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="NineGagComponent.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Fetches, map and filters the nine gag model</summary>
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
    /// Class NineGagComponent.
    /// Implements the <see cref="ComedyHub.Core.Components.Contracts.INineGagComponent" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Components.Contracts.INineGagComponent" />
    public class NineGagComponent : INineGagComponent
    {
        /// <summary>
        /// The nine gag fetch service
        /// </summary>
        private readonly INineGagFetchService _nineGagFetchService;
        /// <summary>
        /// The filter service
        /// </summary>
        private readonly IFilterService _filterService;
        /// <summary>
        /// The nine gag mapper service
        /// </summary>
        private readonly INineGagMapperService _nineGagMapperService;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<NineGagComponent> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NineGagComponent"/> class.
        /// </summary>
        /// <param name="nineGagFetchService">The nine gag fetch service.</param>
        /// <param name="filterService">The filter service.</param>
        /// <param name="nineGagMapperService">The nine gag mapper service.</param>
        /// <param name="logger">The logger.</param>
        public NineGagComponent(INineGagFetchService nineGagFetchService,
                                IFilterService filterService,
                                INineGagMapperService nineGagMapperService,
                                ILogger<NineGagComponent> logger)
        {
            _nineGagFetchService = nineGagFetchService;
            _filterService = filterService;
            _nineGagMapperService = nineGagMapperService;
            _logger = logger;
        }
        /// <summary>
        /// Gets the nine gag meme.
        /// </summary>
        /// <returns>The meme model</returns>
        public async Task<MemeModel> GetNineGagMeme()
        {
            var nineGagModels = await _nineGagFetchService.GetNineGagModelMeme();

            _logger.LogInformation("Received nine gag memes");

            var nineGagPostModel = _nineGagMapperService.NineGagModelToMemes(nineGagModels);

            _logger.LogInformation("Mapped to memes models");

            var memeModel = await _filterService.FilterMemes(nineGagPostModel);

            _logger.LogInformation("Filtered memes models to meme models");

            return memeModel;
        }
    }
}
