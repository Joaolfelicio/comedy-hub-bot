// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 01-08-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="TwitterAuth.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ComedyHub.Core.Auth
{
    using ComedyHub.Core.Auth.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Tweetinvi;

    /// <summary>
    /// Class TwitterAuth.
    /// Implements the <see cref="ComedyHub.Core.Auth.Contracts.ITwitterAuth" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Auth.Contracts.ITwitterAuth" />
    public class TwitterAuth : ITwitterAuth
    {
        /// <summary>
        /// Sets the twitter authentication.
        /// </summary>
        public void SetTwitterAuth()
        {

            Auth.SetUserCredentials(ConsumerToken.CONSUMER_KEY_TWITTER, ConsumerToken.CONSUMER_SECRET_TWITTER,
                                    AccessToken.ACCESS_TOKEN_TWITTER, AccessToken.ACCESS_TOKEN_SECRET_TWITTER);
        }
    }
}
