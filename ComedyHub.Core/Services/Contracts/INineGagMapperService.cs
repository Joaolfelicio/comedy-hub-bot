// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-28-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="INineGagMapperService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Maps the nine gag model to the desired model</summary>
// ***********************************************************************
using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using ComedyHub.Model.Meme;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    /// <summary>
    /// Interface INineGagMapperService
    /// </summary>
    public interface INineGagMapperService
    {
        /// <summary>
        /// Nines the gag model to memes.
        /// </summary>
        /// <param name="ngPosts">The ng posts.</param>
        /// <returns>The list of the meme models.</returns>
        List<MemeModel> NineGagModelToMemes(NineGagModel ngPosts);
    }
}
