// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 12-28-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="INineGagComponent.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ComedyHub.Model.Meme;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components.Contracts
{
    /// <summary>
    /// Interface INineGagComponent
    /// </summary>
    public interface INineGagComponent
    {

        /// <summary>
        /// Gets the nine gag meme.
        /// </summary>
        /// <returns>The meme model</returns>
        Task<MemeModel> GetNineGagMeme();
    }
}
