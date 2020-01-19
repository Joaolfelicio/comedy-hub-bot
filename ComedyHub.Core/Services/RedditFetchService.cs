// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="RedditFetchService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Fetch the reddit meme</summary>
// ***********************************************************************
using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using ComedyHub.Core.Services.Contracts;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    /// <summary>
    /// Class RedditFetchService.
    /// Implements the <see cref="ComedyHub.Core.Services.Contracts.IRedditFetchService" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Services.Contracts.IRedditFetchService" />
    public class RedditFetchService : IRedditFetchService
    {
        /// <summary>
        /// The reddit gateway
        /// </summary>
        private readonly IRedditGateway _redditGateway;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedditFetchService"/> class.
        /// </summary>
        /// <param name="redditGateway">The reddit gateway.</param>
        public RedditFetchService(IRedditGateway redditGateway)
        {
            _redditGateway = redditGateway;
        }
        /// <summary>
        /// Gets the reddit model meme.
        /// </summary>
        /// <returns>List of posts.</returns>
        public List<Post> GetRedditModelMeme()
        {
            return _redditGateway.GetRedditMeme();
        }
    }
}
