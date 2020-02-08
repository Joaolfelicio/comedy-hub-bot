// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="Data.cs" company="ComedyHub.Core">
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
    /// Class Data.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>The posts.</value>
        public List<NineGagPost> Posts { get; set; }
        /// <summary>
        /// Gets or sets the next cursor.
        /// </summary>
        /// <value>The next cursor.</value>
        public string NextCursor { get; set; }
    }
}
