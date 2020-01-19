// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-28-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 12-28-2019
// ***********************************************************************
// <copyright file="INineGagApiSettings.cs" company="ComedyHub.Core">
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
    /// Interface INineGagApiSettings
    /// </summary>
    public interface INineGagApiSettings
    {
        /// <summary>
        /// Gets the API URL.
        /// </summary>
        /// <value>The API URL.</value>
        string Url { get; }
    }
}
