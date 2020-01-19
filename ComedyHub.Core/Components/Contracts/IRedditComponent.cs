// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="IRedditComponent.cs" company="ComedyHub.Core">
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
    /// Interface IRedditComponent
    /// </summary>
    public interface IRedditComponent
    {
        /// <summary>
        /// Gets the reddit meme.
        /// </summary>
        /// <returns>The MemeModel</returns>
        Task<MemeModel> GetRedditMeme();
    }
}
