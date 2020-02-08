// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="FilterService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Filters the memes</summary>
// ***********************************************************************
using ComedyHub.Core.Auth.Contracts;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Tweetinvi;
using ComedyHub.Core.Constants;
using System.Net.Http;
using System.Threading.Tasks;
using ComedyHub.Core.Infrastructure.Gateway.Contracts;

namespace ComedyHub.Core.Services
{
    /// <summary>
    /// Class FilterService.
    /// Implements the <see cref="ComedyHub.Core.Services.Contracts.IFilterService" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Services.Contracts.IFilterService" />
    public class FilterService : IFilterService
    {
        /// <summary>
        /// The twitter bot settings
        /// </summary>
        private readonly ITwitterBotSettings _twitterBotSettings;
        /// <summary>
        /// The twitter authentication
        /// </summary>
        private readonly ITwitterAuth _twitterAuth;
        /// <summary>
        /// The application settings
        /// </summary>
        private readonly IApplicationSettings _applicationSettings;
        /// <summary>
        /// The content gateway
        /// </summary>
        private readonly IContentGateway _contentGateway;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterService"/> class.
        /// </summary>
        /// <param name="twitterBotSettings">The twitter bot settings.</param>
        /// <param name="twitterAuth">The twitter authentication.</param>
        /// <param name="applicationSettings">The application settings.</param>
        /// <param name="contentGateway">The content gateway.</param>
        public FilterService(ITwitterBotSettings twitterBotSettings,
                             ITwitterAuth twitterAuth,
                             IApplicationSettings applicationSettings,
                             IContentGateway contentGateway)
        {
            _twitterBotSettings = twitterBotSettings;
            _twitterAuth = twitterAuth;
            _applicationSettings = applicationSettings;
            _contentGateway = contentGateway;
        }

        /// <summary>
        /// Filters the memes.
        /// </summary>
        /// <param name="posts">The posts.</param>
        /// <returns>The meme model.</returns>
        public async Task<MemeModel> FilterMemes(List<MemeModel> posts)
        {
            var postsWithImage = RemovePostsWithoutImage(posts);

            var imagesWithSizeLimit = await RemoveImagesWithSizeLimit(postsWithImage);

            var distinctPosts = RemoveDuplicates(imagesWithSizeLimit);

            var randomFilteredMeme = GetRandomPost(distinctPosts);

            return randomFilteredMeme;
        }

        /// <summary>
        /// Gets the random post.
        /// </summary>
        /// <param name="posts">The posts.</param>
        /// <returns>The random MemeModel.</returns>
        private MemeModel GetRandomPost(List<MemeModel> posts)
        {
            var random = new Random();
            var randomPostIndex = random.Next(posts.Count);

            return posts[randomPostIndex];
        }

        /// <summary>
        /// Removes the duplicates.
        /// </summary>
        /// <param name="posts">The posts.</param>
        /// <returns>The list of meme models that were not published before.</returns>
        private List<MemeModel> RemoveDuplicates(List<MemeModel> posts)
        {
            string botScreenName = _twitterBotSettings.BotScreenName;
            int numberStatusToFetch = _twitterBotSettings.NumStatusToFetch;

            var notDuplicatedPosts = new List<MemeModel>(posts);

            //Set authorization on twitter
            _twitterAuth.SetTwitterAuth();

            var lastTweets = Timeline.GetUserTimeline(botScreenName, numberStatusToFetch);

            foreach (var post in posts)
            {
                foreach (var postedTweet in lastTweets)
                {
                    // Has the meme posted before?
                    if (postedTweet.Text == post.Title)
                    {
                        notDuplicatedPosts.Remove(post);
                        break;
                    }
                }
            }
            return notDuplicatedPosts;
        }

        /// <summary>
        /// Removes the posts without image.
        /// </summary>
        /// <param name="posts">The posts.</param>
        /// <returns>The list of meme models with images.</returns>
        private List<MemeModel> RemovePostsWithoutImage(List<MemeModel> posts)
        {
            var postsWithImage = new List<MemeModel>();

            foreach (var post in posts)
            {
                if (post.MediaType == MediaType.MediaFilePhoto)
                {
                    postsWithImage.Add(post);
                }
            }
            return postsWithImage;
        }

        /// <summary>
        /// Removes the images with size limit.
        /// </summary>
        /// <param name="posts">The posts.</param>
        /// <returns>The list of posts with less than the size limit (for the image).</returns>
        private async Task<List<MemeModel>> RemoveImagesWithSizeLimit(List<MemeModel> posts)
        {
            //Multiply to convert from MegaByte to Bytes
            var sizeLimitBytes = _applicationSettings.SizeLimitMegaBytes * 1048576;

            var imagesWithSizeLimit = new List<MemeModel>();

            foreach (var post in posts)
            {
                var imageHeaders = await _contentGateway.GetContentHeaders(post.ImageUrl);

                if (sizeLimitBytes > imageHeaders.ContentLength)
                {
                    imagesWithSizeLimit.Add(post);
                }
            }
            return imagesWithSizeLimit;
        }
    }
}
