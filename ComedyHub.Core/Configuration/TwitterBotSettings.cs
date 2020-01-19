// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-05-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="TwitterBotSettings.cs" company="ComedyHub.Core">
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
    /// Class TwitterBotSettings.
    /// Implements the <see cref="ComedyHub.Core.Configuration.Contracts.ITwitterBotSettings" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Configuration.Contracts.ITwitterBotSettings" />
    public class TwitterBotSettings : ITwitterBotSettings
    {
        /// <summary>
        /// Gets or sets the screen name of the bot, starting with "@".
        /// </summary>
        /// <value>The screen name of the bot.</value>
        public string BotScreenName { get; set; }
        /// <summary>
        /// Gets or sets the number of status to fetch.
        /// </summary>
        /// <value>The number of status to fetch.</value>
        public int NumStatusToFetch { get; set; }
    }
}
