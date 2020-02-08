// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="IRedditMapperService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Maps the reddit model to the desired model</summary>
// ***********************************************************************
using ComedyHub.Model.Meme;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    /// <summary>
    /// Interface IRedditMapperService
    /// </summary>
    public interface IRedditMapperService
    {
        /// <summary>
        /// Reddits the model to memes.
        /// </summary>
        /// <param name="redditPosts">The reddit posts.</param>
        /// <returns>The list of meme models.</returns>
        List<MemeModel> RedditModelToMemes(List<Post> redditPosts);
    }
}
