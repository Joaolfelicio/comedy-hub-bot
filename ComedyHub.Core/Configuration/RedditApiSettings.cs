// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="RedditApiSettings.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ComedyHub.Core.Configuration.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Configuration
{
    /// <summary>
    /// Class RedditApiSettings.
    /// Implements the <see cref="ComedyHub.Core.Configuration.Contracts.IRedditApiSettings" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Configuration.Contracts.IRedditApiSettings" />
    public class RedditApiSettings : IRedditApiSettings
    {
        /// <summary>
        /// Gets or sets the subreddit to fetch.
        /// </summary>
        /// <value>The subreddit to fetch.</value>
        public string SubredditToFetch { get; set; }

        /// <summary>
        /// Gets or sets the number of posts to receive.
        /// </summary>
        /// <value>The number of posts to receive.</value>
        public int NumPostsToReceive {get; set; }
}
}
