// ***********************************************************************
// Assembly         : ComedyHub.Model
// Author           : Joaolfelicio
// Created          : 01-05-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="PublishedModel.cs" company="ComedyHub.Model">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Model.Publish
{
    /// <summary>
    /// Class PublishedModel.
    /// </summary>
    public class PublishedModel
    {
        /// <summary>
        /// Gets or sets the published URL.
        /// </summary>
        /// <value>The published URL.</value>
        public string PublishedURL { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        public string ImageUrl  { get; set; }
        /// <summary>
        /// Gets or sets the published at.
        /// </summary>
        /// <value>The published at.</value>
        public string PublishedAt { get; set; }
        /// <summary>
        /// Gets or sets the meme provider.
        /// </summary>
        /// <value>The meme provider.</value>
        public string MemeProvider { get; set; }
    }
}
