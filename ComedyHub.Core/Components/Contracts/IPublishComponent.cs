// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 12-28-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="IPublishComponent.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ComedyHub.Model.Meme;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Components.Contracts
{
    /// <summary>
    /// Interface IPublishComponent
    /// </summary>
    public interface IPublishComponent
    {
        /// <summary>
        /// Publishes the meme.
        /// </summary>
        /// <param name="memeModel">The meme model.</param>
        /// <returns>The PublishedModel.</returns>
        PublishedModel PublishMeme(MemeModel memeModel);
    }
}
