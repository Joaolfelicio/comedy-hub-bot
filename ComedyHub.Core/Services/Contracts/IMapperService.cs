// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="IMapperService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Mapps the memes to the desired model</summary>
// ***********************************************************************
using ComedyHub.Model.Meme;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    /// <summary>
    /// Interface IMapperService
    /// </summary>
    public interface IMapperService
    {
        /// <summary>
        /// Maps to meme models.
        /// </summary>
        /// <param name="memeModels">The meme models.</param>
        /// <returns>List of meme models.</returns>
        List<MemeModel> MapToMemeModels(List<MemeModel> memeModels);
    }
}
