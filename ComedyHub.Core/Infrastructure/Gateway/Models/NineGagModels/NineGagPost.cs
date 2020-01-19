// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="NineGagPost.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels
{
    /// <summary>
    /// Class NineGagPost.
    /// </summary>
    public class NineGagPost
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
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets the Not Safe For Work.
        /// </summary>
        /// <value>The NSFW.</value>
        public int Nsfw { get; set; }
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
        /// Gets or sets the creation time stamp.
        /// </summary>
        /// <value>The creation time stamp.</value>
        public long CreationTs { get; set; }
        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        public Images Images { get; set; }
        /// <summary>
        /// Gets or sets the comments count.
        /// </summary>
        /// <value>The comments count.</value>
        public int CommentsCount { get; set; }
        /// <summary>
        /// Gets or sets the post section.
        /// </summary>
        /// <value>The post section.</value>
        public PostSection PostSection { get; set; }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public List<Tag> Tags { get; set; }
        /// <summary>
        /// Gets or sets the description in HTML.
        /// </summary>
        /// <value>The description in HTML.</value>
        public string DescriptionHtml { get; set; }
    }
}
