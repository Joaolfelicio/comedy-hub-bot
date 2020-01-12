using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Components
{
    public class RedditComponent : IRedditComponent
    {
        private readonly IRedditFetchService _redditFetchService;
        private readonly IRedditFilterService _redditFilterService;
        private readonly IRedditMapperService _redditMapperService;

        public RedditComponent(IRedditFetchService redditFetchService,
                               IRedditFilterService redditFilterService,
                               IRedditMapperService redditMapperService)
        {
            _redditFetchService = redditFetchService;
            _redditFilterService = redditFilterService;
            _redditMapperService = redditMapperService;
        }
        public MemeModel GetRedditMeme()
        {
            var redditMemes = _redditFetchService.GetRedditModelMeme();

            var filteredMeme = _redditFilterService.RedditFilter(redditMemes);

            var mappedMeme = _redditMapperService.RedditModelToMeme(filteredMeme);

            return mappedMeme;
        }
    }
}
