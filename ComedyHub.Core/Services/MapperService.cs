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

        public MemeModel MapToMemeModel(MemeModel memeModel)
        {
            return AddTagsToTitle(memeModel);
        }

        private MemeModel AddTagsToTitle(MemeModel memeModel)
        {
            var title = memeModel.Title;

            //The default tags on the appsettings
            var defaultTags = _applicationSettings.DefaultTags.Split(';');

            //Default tags list
            var tags = new List<string>(defaultTags);

            if (memeModel.Tags != null && memeModel.Tags.Count > 0)
            {
                //Tags from the meme
                var memeTags = new List<string>(memeModel.Tags);

                //Put everything together, default tags more meme tags
                tags.AddRange(memeTags);
            }

            //Get only the ones that are distincts
            tags = tags.Distinct().ToList();

            foreach (var tag in tags)
            {
                title = title + " #" + tag;
            }

            memeModel.Title = title;

            return memeModel;
        }
    }
}
