// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-27-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-12-2020
// ***********************************************************************
// <copyright file="NineGagGateway.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;

namespace ComedyHub.Core.Infrastructure.Gateway
{
    /// <summary>
    /// Class NineGagGateway.
    /// Implements the <see cref="ComedyHub.Core.Infrastructure.Gateway.Contracts.INineGagGateway" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Infrastructure.Gateway.Contracts.INineGagGateway" />
    public class NineGagGateway : INineGagGateway
    {
        /// <summary>
        /// The nine gag API settings
        /// </summary>
        private readonly INineGagApiSettings _nineGagApiSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="NineGagGateway"/> class.
        /// </summary>
        /// <param name="nineGagApiSettings">The nine gag API settings.</param>
        public NineGagGateway(INineGagApiSettings nineGagApiSettings)
        {
            _nineGagApiSettings = nineGagApiSettings;
        }
        /// <summary>
        /// Gets the nine gag meme.
        /// </summary>
        /// <returns>The Nine Gag Model.</returns>
        public async Task<NineGagModel> GetNineGagMeme()
        {
            NineGagModel memeModel = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_nineGagApiSettings.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(_nineGagApiSettings.Url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    memeModel = JsonConvert.DeserializeObject<NineGagModel>(data);

                    return memeModel;
                }
            }
            return memeModel;
        }
    }
}
