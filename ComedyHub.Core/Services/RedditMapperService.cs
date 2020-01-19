// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="RedditMapperService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Mapps from reddit meme to the meme model</summary>
// ***********************************************************************
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using ComedyHub.Core.Constants;
using ComedyHub.Core.Configuration.Contracts;
using System.Linq;

namespace ComedyHub.Core.Services
{
    /// <summary>
    /// Class RedditMapperService.
    /// Implements the <see cref="ComedyHub.Core.Services.Contracts.IRedditMapperService" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Services.Contracts.IRedditMapperService" />
    public class RedditMapperService : IRedditMapperService
    {
        /// <summary>
        /// The mapper service
        /// </summary>
        private readonly IMapperService _mapperService;
        /// <summary>
        /// The application settings
        /// </summary>
        private readonly IApplicationSettings _applicationSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedditMapperService"/> class.
        /// </summary>
        /// <param name="mapperService">The mapper service.</param>
        /// <param name="applicationSettings">The application settings.</param>
        public RedditMapperService(IMapperService mapperService,
                                   IApplicationSettings applicationSettings)
        {
            _mapperService = mapperService;
            _applicationSettings = applicationSettings;
        }

        /// <summary>
        /// From reddit model to memes model.
        /// </summary>
        /// <param name="redditPosts">The reddit posts.</param>
        /// <returns>The list of meme models.</returns>
        public List<MemeModel> RedditModelToMemes(List<Post> redditPosts)
        {
            var mappedMemes = new List<MemeModel>();
            var imageExtensionsSupported = _applicationSettings.SupportedImageExtensions.Split(';').ToList();

            foreach (var post in redditPosts)
            {
                var fileExtension = Path.GetExtension(post.Listing.URL);

                var meme = new MemeModel()
                {
                    Id = post.Id,
                    CommentsCount = post.Listing.NumComments,
                    DownVoteCount = post.DownVotes,
                    Title = HttpUtility.HtmlDecode(post.Title),
                    Nsfw = post.NSFW,
                    ImageUrl = post.Listing.URL,
                    PublishedDate = post.Created,
                    UpVoteCount = post.UpVotes,
                    FileExtension = fileExtension,
                    Url = post.Permalink,
                    Provider = MemeProvider.Reddit,
                    MediaType = imageExtensionsSupported.Contains(fileExtension) ? MediaType.MediaFilePhoto : MediaType.MediaFileAnimated
                };
             mappedMemes.Add(meme);
            }

            //Common mapping method between the memes services
            mappedMemes = _mapperService.MapToMemeModels(mappedMemes);

            return mappedMemes;
        }
    }
}
