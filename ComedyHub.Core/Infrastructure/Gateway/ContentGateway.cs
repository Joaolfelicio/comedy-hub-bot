// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-19-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="ContentGateway.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Infrastructure.Gateway
{
    /// <summary>
    /// Class ContentGateway.
    /// Implements the <see cref="ComedyHub.Core.Infrastructure.Gateway.Contracts.IContentGateway" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Infrastructure.Gateway.Contracts.IContentGateway" />
    public class ContentGateway : IContentGateway
    {
        /// <summary>
        /// Gets the content headers.
        /// </summary>
        /// <param name="url">The URL to fetch.</param>
        /// <returns>The Headers</returns>
        public async Task<HttpContentHeaders> GetContentHeaders(string url)
        {
            using (var client = new HttpClient())
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Head, url);

                var responseMessage = await client.SendAsync(requestMessage);

                var responseMessageHeaders = responseMessage.Content.Headers;

                return responseMessageHeaders;
            }
        }
    }
}
