// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-18-2020
// ***********************************************************************
// <copyright file="RedditGateway.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ComedyHub.Core.Auth;
using ComedyHub.Core.Auth.Contracts;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using Reddit;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Infrastructure.Gateway
{
    /// <summary>
    /// Class RedditGateway.
    /// Implements the <see cref="ComedyHub.Core.Infrastructure.Gateway.Contracts.IRedditGateway" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Infrastructure.Gateway.Contracts.IRedditGateway" />
    public class RedditGateway : IRedditGateway
    {
        /// <summary>
        /// The reddit API settings
        /// </summary>
        private readonly IRedditApiSettings _redditApiSettings;
        /// <summary>
        /// The reddit authentication
        /// </summary>
        private readonly IRedditAuth _redditAuth;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedditGateway"/> class.
        /// </summary>
        /// <param name="redditApiSettings">The reddit API settings.</param>
        /// <param name="redditAuth">The reddit authentication.</param>
        public RedditGateway(IRedditApiSettings redditApiSettings,
                             IRedditAuth redditAuth)
        {
            _redditApiSettings = redditApiSettings;
            _redditAuth = redditAuth;
        }
        /// <summary>
        /// Gets the reddit meme.
        /// </summary>
        /// <returns>The list of posts</returns>
        public List<Post> GetRedditMeme()
        {
            string subredditToFetch = _redditApiSettings.SubredditToFetch;
            int numPostsToReceive = _redditApiSettings.NumPostsToReceive;

            var redditApi = _redditAuth.SetRedditAuth();

            var askReddit = redditApi.Subreddit(subredditToFetch).About();
            var topPosts = askReddit.Posts.GetHot(limit: numPostsToReceive);

            return topPosts;
        }
    }
}
