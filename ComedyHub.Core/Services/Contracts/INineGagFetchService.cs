// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-27-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="INineGagFetchService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Fetches the nine gag memes</summary>
// ***********************************************************************
using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Services.Contracts
{
    /// <summary>
    /// Interface INineGagFetchService
    /// </summary>
    public interface INineGagFetchService
    {
        /// <summary>
        /// Gets the nine gag model meme.
        /// </summary>
        /// <returns>The nine gag model.</returns>
        Task<NineGagModel> GetNineGagModelMeme();
    }
}
