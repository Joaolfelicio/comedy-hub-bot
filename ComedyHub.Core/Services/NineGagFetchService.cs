// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-27-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="NineGagFetchService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Fetch the nine gag meme</summary>
// ***********************************************************************
using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using ComedyHub.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Services
{
    /// <summary>
    /// Class NineGagFetchService.
    /// Implements the <see cref="ComedyHub.Core.Services.Contracts.INineGagFetchService" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Services.Contracts.INineGagFetchService" />
    public class NineGagFetchService : INineGagFetchService
    {
        /// <summary>
        /// The nine gag gateway
        /// </summary>
        readonly INineGagGateway _nineGagGateway;
        /// <summary>
        /// Initializes a new instance of the <see cref="NineGagFetchService"/> class.
        /// </summary>
        /// <param name="nineGagGateway">The nine gag gateway.</param>
        public NineGagFetchService(INineGagGateway nineGagGateway)
        {
            _nineGagGateway = nineGagGateway;
        }

        /// <summary>
        /// Gets the nine gag model meme.
        /// </summary>
        /// <returns>The nine gag model.</returns>
        public async Task<NineGagModel> GetNineGagModelMeme()
        {
            return await _nineGagGateway.GetNineGagMeme();
        }
    }
}
