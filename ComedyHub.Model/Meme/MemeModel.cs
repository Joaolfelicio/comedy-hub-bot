// ***********************************************************************
// Assembly         : ComedyHub.Model
// Author           : Joaolfelicio
// Created          : 01-05-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="MemeModel.cs" company="ComedyHub.Model">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Model.Meme
{
    /// <summary>
    /// Class MemeModel.
    /// </summary>
    public class MemeModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the file extension.
        /// </summary>
        /// <value>The file extension.</value>
        public string FileExtension { get; set; }
        /// <summary>
        /// Gets or sets the type of the media.
        /// </summary>
        /// <value>The type of the media.</value>
        public string MediaType { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MemeModel"/> is Not Safe For Work or not.
        /// </summary>
        /// <value><c>true</c> if NSFW; otherwise, <c>false</c>.</value>
        public bool Nsfw { get; set; }
        /// <summary>
        /// Gets or sets up vote count.
        /// </summary>
        /// <value>Up vote count.</value>
        public int UpVoteCount { get; set; }
        /// <summary>
        /// Gets or sets down vote count.
        /// </summary>
        /// <value>Down vote count.</value>
        public int DownVoteCount { get; set; }
        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Gets or sets the comments count.
        /// </summary>
        /// <value>The comments count.</value>
        public int CommentsCount { get; set; }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public List<string> Tags { get; set; }
        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public string Provider { get; set; }
        /// <summary>
        /// Gets or sets the published date.
        /// </summary>
        /// <value>The published date.</value>
        public DateTime PublishedDate { get; set; }
    }
}
