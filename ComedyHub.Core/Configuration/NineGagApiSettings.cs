// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-28-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 12-28-2019
// ***********************************************************************
// <copyright file="NineGagApiSettings.cs" company="ComedyHub.Core">
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
    /// Class NineGagApiSettings.
    /// Implements the <see cref="ComedyHub.Core.Configuration.Contracts.INineGagApiSettings" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Configuration.Contracts.INineGagApiSettings" />
    public class NineGagApiSettings : INineGagApiSettings
    {
        /// <summary>
        /// Gets or sets the API URL.
        /// </summary>
        /// <value>The API URL.</value>
        public string Url { get ; set ; }
    }
}
