// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-27-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="INineGagGateway.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Infrastructure.Gateway.Contracts
{
    /// <summary>
    /// Interface INineGagGateway
    /// </summary>
    public interface INineGagGateway
    {
        /// <summary>
        /// Gets the nine gag meme.
        /// </summary>
        /// <returns>The Nine Gag Model.</returns>
        Task<NineGagModel> GetNineGagMeme();
    }
}
