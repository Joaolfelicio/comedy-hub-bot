// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="IRedditGateway.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.Gateway.Contracts
{
    /// <summary>
    /// Interface IRedditGateway
    /// </summary>
    public interface IRedditGateway
    {
        /// <summary>
        /// Gets the reddit meme.
        /// </summary>
        /// <returns>The list of posts</returns>
        List<Post> GetRedditMeme();
    }
}
