// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-19-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="IContentGateway.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Infrastructure.Gateway.Contracts
{
    /// <summary>
    /// Interface IContentGateway
    /// </summary>
    public interface IContentGateway
    {
        /// <summary>
        /// Gets the content headers.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The Headers</returns>
        Task<HttpContentHeaders> GetContentHeaders(string url);
    }
}
