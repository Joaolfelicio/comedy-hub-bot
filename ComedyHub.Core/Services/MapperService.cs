using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class MapperService : IMapperService
    {
        private readonly IApplicationSettings _applicationSettings;

        public MapperService(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public List<MemeModel> MapToMemeModels(List<MemeModel> memeModels)
        {
            return AddTagsToTitle(memeModels);
        }

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

                //Get only the ones that are distincts
                tagsList = tagsList.Distinct().ToList();

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
