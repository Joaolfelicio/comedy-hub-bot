// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : joaolfelicio
// Created          : 01-08-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-08-2020
// ***********************************************************************
// <copyright file="ITwitterAuth.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Auth.Contracts
{
    /// <summary>
    /// Interface ITwitterAuth
    /// </summary>
    public interface ITwitterAuth
    {
        /// <summary>
        /// Sets the twitter authentication.
        /// </summary>
        void SetTwitterAuth();
    }
}
