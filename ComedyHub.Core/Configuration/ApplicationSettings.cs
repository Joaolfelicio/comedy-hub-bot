// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-28-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="ApplicationSettings.cs" company="ComedyHub.Core">
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
    /// Class ApplicationSettings.
    /// Implements the <see cref="ComedyHub.Core.Configuration.Contracts.IApplicationSettings" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Configuration.Contracts.IApplicationSettings" />
    public class ApplicationSettings : IApplicationSettings
    {
        /// <summary>
        /// Gets or sets the services to fetch, CSV.
        /// </summary>
        /// <value>The services to fetch.</value>
        public string ServicesToFetch { get; set; }
        /// <summary>
        /// Gets or sets the default tags, CSV.
        /// </summary>
        /// <value>The default tags.</value>
        public string DefaultTags { get; set; }
        /// <summary>
        /// Gets or sets the supported image extensions, CSV.
        /// </summary>
        /// <value>The supported image extensions.</value>
        public string SupportedImageExtensions { get; set; }
        /// <summary>
        /// Gets or sets the size limit in mega bytes.
        /// </summary>
        /// <value>The size limit in mega bytes.</value>
        public int SizeLimitMegaBytes { get; set; }
    }
}
