// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="IFilterService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Filters the memes</summary>
// ***********************************************************************
using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using ComedyHub.Model.Meme;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Services.Contracts
{
    /// <summary>
    /// Interface IFilterService
    /// </summary>
    public interface IFilterService
    {
        /// <summary>
        /// Filters the memes.
        /// </summary>
        /// <param name="posts">The posts.</param>
        /// <returns>The meme model.</returns>
        Task<MemeModel> FilterMemes(List<MemeModel> posts);
    }
}