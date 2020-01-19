// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="IRedditFetchService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Fetchs the reddit memes</summary>
// ***********************************************************************
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    /// <summary>
    /// Interface IRedditFetchService
    /// </summary>
    public interface IRedditFetchService
    {
        /// <summary>
        /// Gets the reddit model meme.
        /// </summary>
        /// <returns>List of posts.</returns>
        List<Post> GetRedditModelMeme();
    }
}
