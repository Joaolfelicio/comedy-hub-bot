// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 12-27-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-05-2020
// ***********************************************************************
// <copyright file="IMemeOrchestrator.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components.Contracts
{
    /// <summary>
    /// Interface IMemeOrchestrator
    /// </summary>
    public interface IMemeOrchestrator
    {
        /// <summary>
        /// Processes this instance.
        /// </summary>
        /// <returns></returns>
        Task Process();
    }
}
