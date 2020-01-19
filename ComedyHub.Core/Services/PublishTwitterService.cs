// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 12-28-2019
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="PublishTwitterService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Publish the meme throught twitter</summary>
// ***********************************************************************
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Core;
using ComedyHub.Model.Meme;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using ComedyHub.Core.Auth.Contracts;

namespace ComedyHub.Core.Services
{
    /// <summary>
    /// Class PublishTwitterService.
    /// Implements the <see cref="ComedyHub.Core.Services.Contracts.IPublishTwitterService" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Services.Contracts.IPublishTwitterService" />
    public class PublishTwitterService : IPublishTwitterService
    {

        /// <summary>
        /// Publishes to twitter.
        /// </summary>
        /// <param name="memeModel">The meme model.</param>
        /// <returns>The PublishedModel.</returns>
        public PublishedModel PublishToTwitter(MemeModel memeModel)
        { 
            var imageList = new List<byte[]>();

            using (var webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(memeModel.ImageUrl);
                imageList.Add(imageBytes);
            }

            var tweetParameters = new PublishTweetOptionalParameters()
            {
                PossiblySensitive = memeModel.Nsfw,
                MediaBinaries = imageList
            };
            var tweetPublished = Tweet.PublishTweet(memeModel.Title, tweetParameters);

            return new PublishedModel()
            {
                PublishedURL = tweetPublished.Url,
                Message = $"Successfully published meme.",
                MemeProvider = memeModel.Provider,
                PublishedAt = "Twitter",
                ImageUrl = memeModel.ImageUrl
            };
        }
    }
}
