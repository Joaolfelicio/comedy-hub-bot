// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-28-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="PublishComponent.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Handles the publish process</summary>
// ***********************************************************************
using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Components
{
    /// <summary>
    /// Class PublishComponent.
    /// Implements the <see cref="ComedyHub.Core.Components.Contracts.IPublishComponent" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Components.Contracts.IPublishComponent" />
    public class PublishComponent : IPublishComponent
    {
        /// <summary>
        /// The publish twitter service
        /// </summary>
        private readonly IPublishTwitterService _publishTwitterService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishComponent"/> class.
        /// </summary>
        /// <param name="publishTwitterService">The publish twitter service.</param>
        public PublishComponent(IPublishTwitterService publishTwitterService)
        {
            _publishTwitterService = publishTwitterService;
        }
        /// <summary>
        /// Publishes the meme.
        /// </summary>
        /// <param name="memeModel">The meme model.</param>
        /// <returns>The PublishedModel.</returns>
        public PublishedModel PublishMeme(MemeModel memeModel)
        {
            return _publishTwitterService.PublishToTwitter(memeModel);
        }
    }
}
