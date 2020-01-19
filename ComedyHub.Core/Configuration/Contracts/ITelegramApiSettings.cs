// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-05-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="ITelegramApiSettings.cs" company="ComedyHub.Core">
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
    /// Interface ITelegramApiSettings
    /// </summary>
    public interface ITelegramApiSettings
    {
        /// <summary>
        /// Gets the API URL.
        /// </summary>
        /// <value>The URL.</value>
        string Url { get; }
        /// <summary>
        /// Gets the parse mode used to format the message.
        /// </summary>
        /// <value>The parse mode.</value>
        string ParseMode { get; }
    }
}
