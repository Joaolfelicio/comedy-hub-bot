// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="IRedditAuth.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Reddit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Auth.Contracts
{
    /// <summary>
    /// Interface IRedditAuth
    /// </summary>
    public interface IRedditAuth
    {
        /// <summary>
        /// Sets the reddit authentication.
        /// </summary>
        /// <returns>Reddit API Client</returns>
        RedditClient SetRedditAuth();
    }
}
