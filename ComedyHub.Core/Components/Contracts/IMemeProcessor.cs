// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 12-27-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="IMemeProcessor.cs" company="ComedyHub.Core">
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
    /// Interface IMemeProcessor
    /// </summary>
    public interface IMemeProcessor
    {
        /// <summary>
        /// Processes the meme.
        /// </summary>
        /// <returns>The meme model</returns>
        Task<MemeModel> ProcessMeme();
    }
}
