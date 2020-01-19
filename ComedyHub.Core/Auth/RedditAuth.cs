// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="RedditAuth.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ComedyHub.Core.Auth.Contracts;
using Reddit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Auth
{
    /// <summary>
    /// Class RedditAuth.
    /// Implements the <see cref="ComedyHub.Core.Auth.Contracts.IRedditAuth" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Auth.Contracts.IRedditAuth" />
    public class RedditAuth : IRedditAuth
    {
        /// <summary>
        /// Sets the reddit authentication.
        /// </summary>
        /// <returns>Reddit API Client</returns>
        public RedditClient SetRedditAuth()
        {
            return new RedditClient(AppInfo.REDDIT_APP_ID, ConsumerToken.CONSUMER_REFRESH_REDDIT, ConsumerToken.CONSUMER_SECRET_REDDIT);
        }
    }
}
