// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="IRedditApiSettings.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Configuration.Contracts
{
    /// <summary>
    /// Interface IRedditApiSettings
    /// </summary>
    public interface IRedditApiSettings
    {
        /// <summary>
        /// Gets the subreddit to fetch.
        /// </summary>
        /// <value>The subreddit to fetch.</value>
        string SubredditToFetch { get; }
        /// <summary>
        /// Gets the number of posts to receive.
        /// </summary>
        /// <value>The number posts to receive.</value>
        int NumPostsToReceive { get; }
    }
}
