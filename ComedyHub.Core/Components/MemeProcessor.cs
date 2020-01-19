// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-27-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="MemeProcessor.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Process the memes</summary>
// ***********************************************************************
using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Configuration;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components
{
    /// <summary>
    /// Class MemeProcessor.
    /// Implements the <see cref="ComedyHub.Core.Components.Contracts.IMemeProcessor" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Components.Contracts.IMemeProcessor" />
    public class MemeProcessor : IMemeProcessor
    {
        /// <summary>
        /// The application settings
        /// </summary>
        private readonly IApplicationSettings _applicationSettings;
        /// <summary>
        /// The nine gag component
        /// </summary>
        private readonly INineGagComponent _nineGagComponent;
        /// <summary>
        /// The reddit component
        /// </summary>
        private readonly IRedditComponent _redditComponent;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemeProcessor"/> class.
        /// </summary>
        /// <param name="applicationSettings">The application settings.</param>
        /// <param name="nineGagComponent">The nine gag component.</param>
        /// <param name="redditComponent">The reddit component.</param>
        public MemeProcessor(IApplicationSettings applicationSettings,
                             INineGagComponent nineGagComponent,
                             IRedditComponent redditComponent)
        {
            _applicationSettings = applicationSettings;
            _nineGagComponent = nineGagComponent;
            _redditComponent = redditComponent;
        }


        /// <summary>
        /// Processes the meme.
        /// </summary>
        /// <returns>The meme model</returns>
        public async Task<MemeModel> ProcessMeme()
        {
            return await ProcessRandomService();
        }


        /// <summary>
        /// Processes the random service.
        /// </summary>
        /// <returns>The MemeModel</returns>
        private async Task<MemeModel> ProcessRandomService()
        {
            var servicesToFetch = _applicationSettings.ServicesToFetch.Split(';');

            Random random = new Random();

            int randomNum = random.Next(servicesToFetch.Length);

            switch (servicesToFetch[randomNum])
            {
                case Constants.MemeProvider.NineGag:
                    return await _nineGagComponent.GetNineGagMeme();

                case Constants.MemeProvider.Reddit:
                    return await _redditComponent.GetRedditMeme();

                default:
                    return await _nineGagComponent.GetNineGagMeme();
            }

        }
    }
}
