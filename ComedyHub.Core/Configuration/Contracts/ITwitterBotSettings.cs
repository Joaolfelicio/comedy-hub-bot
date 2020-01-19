// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-05-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="ITwitterBotSettings.cs" company="ComedyHub.Core">
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
    /// Interface ITwitterBotSettings
    /// </summary>
    public interface ITwitterBotSettings
    {
        /// <summary>
        /// Gets the screen name of the bot, starting with "@".
        /// </summary>
        /// <value>The screen name of the bot.</value>
        string BotScreenName { get; }
        /// <summary>
        /// Gets the number of status to fetch.
        /// </summary>
        /// <value>The number of status to fetch.</value>
        int NumStatusToFetch { get; }
    }
}
