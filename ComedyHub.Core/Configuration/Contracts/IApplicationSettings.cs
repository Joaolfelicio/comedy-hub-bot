// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-28-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="IApplicationSettings.cs" company="ComedyHub.Core">
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
    /// Interface IApplicationSettings
    /// </summary>
    public interface IApplicationSettings
    {
        /// <summary>
        /// Gets the services to fetch, CSV.
        /// </summary>
        /// <value>The services to fetch.</value>
        string ServicesToFetch { get;}
        /// <summary>
        /// Gets the default tags, CSV.
        /// </summary>
        /// <value>The default tags.</value>
        string DefaultTags { get; }
        /// <summary>
        /// Gets the supported image extensions, CSV.
        /// </summary>
        /// <value>The supported image extensions.</value>
        string SupportedImageExtensions { get; }
        /// <summary>
        /// Gets the size limit in mega bytes.
        /// </summary>
        /// <value>The size limit mega bytes.</value>
        int SizeLimitMegaBytes { get; }
    }
}
