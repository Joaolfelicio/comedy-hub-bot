// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-28-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="IPublishTwitterService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Publish the meme to twitter</summary>
// ***********************************************************************
using ComedyHub.Model.Meme;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    /// <summary>
    /// Interface IPublishTwitterService
    /// </summary>
    public interface IPublishTwitterService
    {
        /// <summary>
        /// Publishes to twitter.
        /// </summary>
        /// <param name="memeModel">The meme model.</param>
        /// <returns>PublishedModel.</returns>
        PublishedModel PublishToTwitter(MemeModel memeModel);
    }
}
