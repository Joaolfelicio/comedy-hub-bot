// ***********************************************************************
// Assembly         : ComedyHub.Core
// Author           : Joaolfelicio
// Created          : 01-12-2020
//
// Last Modified By : Joaolfelicio
// Last Modified On : 01-19-2020
// ***********************************************************************
// <copyright file="MapperService.cs" company="ComedyHub.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Maps to the meme model</summary>
// ***********************************************************************
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComedyHub.Core.Services
{
    /// <summary>
    /// Class MapperService.
    /// Implements the <see cref="ComedyHub.Core.Services.Contracts.IMapperService" />
    /// </summary>
    /// <seealso cref="ComedyHub.Core.Services.Contracts.IMapperService" />
    public class MapperService : IMapperService
    {
        /// <summary>
        /// The application settings
        /// </summary>
        private readonly IApplicationSettings _applicationSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapperService"/> class.
        /// </summary>
        /// <param name="applicationSettings">The application settings.</param>
        public MapperService(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        /// <summary>
        /// Maps to meme models.
        /// </summary>
        /// <param name="memeModels">The meme models.</param>
        /// <returns>List of meme models.</returns>
        public List<MemeModel> MapToMemeModels(List<MemeModel> memeModels)
        {
            return AddTagsToTitle(memeModels);
        }

        /// <summary>
        /// Adds the tags to title.
        /// </summary>
        /// <param name="memeModels">The meme models.</param>
        /// <returns>The list of meme models with the tags in the title.</returns>
        private List<MemeModel> AddTagsToTitle(List<MemeModel> memeModels)
        {
            //The default tags on the appsettings
            var defaultTags = _applicationSettings.DefaultTags.Split(';').ToList();

            var memesWithTags = new List<MemeModel>();

            foreach (var meme in memeModels)
            {
                var title = meme.Title;

                var tagsList = new List<string>();

                // If the meme has tags
                if (meme.Tags != null && meme.Tags.Count > 0)
                {
                    //Tags from the meme
                    tagsList.AddRange(meme.Tags);
                }

                //Default tags
                tagsList.AddRange(defaultTags);

                //Get only the ones that are distinct
                tagsList = tagsList.Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();

                foreach (var tag in tagsList)
                {
                    title = title + " #" + tag;
                }

                meme.Title = title;
                meme.Tags = tagsList;

                memesWithTags.Add(meme);
            }
            return memesWithTags;
        }
    }
}
