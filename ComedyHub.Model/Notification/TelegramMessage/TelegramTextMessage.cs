// ***********************************************************************
// Assembly         : ComedyHub.Model
// Author           : Joaolfelicio
// Created          : 01-05-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="TelegramTextMessage.cs" company="ComedyHub.Model">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Model.Notification.TelegramMessage
{
    /// <summary>
    /// Class TelegramTextMessage.
    /// Implements the <see cref="ComedyHub.Model.Notification.TelegramMessage.TelegramMessage" />
    /// </summary>
    /// <seealso cref="ComedyHub.Model.Notification.TelegramMessage.TelegramMessage" />
    public class TelegramTextMessage : TelegramMessage
    {
        /// <summary>
        /// Gets or sets the chat identifier.
        /// </summary>
        /// <value>The chat identifier.</value>
        [JsonProperty("chat_id")]
        public int ChatId { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the parse mode for the format.
        /// </summary>
        /// <value>The parse mode.</value>
        [JsonProperty("parse_mode")]
        public string ParseMode { get; set; }
    }
}
