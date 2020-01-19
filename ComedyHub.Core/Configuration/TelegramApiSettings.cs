// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-05-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="TelegramApiSettings.cs" company="ComedyHub.Core">
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
    /// Class TelegramApiSettings.
    /// Implements the <see cref="ComedyHub.Core.Configuration.Contracts.ITelegramApiSettings" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Configuration.Contracts.ITelegramApiSettings" />
    public class TelegramApiSettings : ITelegramApiSettings
    {
        /// <summary>
        /// Gets or sets the API URL.
        /// </summary>
        /// <value>The API URL.</value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the parse mode used to format the message.
        /// </summary>
        /// <value>The parse mode.</value>
        public string ParseMode { get; set; }
    }
}
