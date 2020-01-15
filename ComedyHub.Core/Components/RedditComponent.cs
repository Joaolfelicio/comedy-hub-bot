using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<RedditComponent> _logger;

        public RedditComponent(IRedditFetchService redditFetchService,
                               IRedditFilterService redditFilterService,
                               IRedditMapperService redditMapperService,
                               ILogger<RedditComponent> logger)
        {
            _redditFetchService = redditFetchService;
            _redditFilterService = redditFilterService;
            _redditMapperService = redditMapperService;
            _logger = logger;
        }
        public MemeModel GetRedditMeme()
        {
            var redditMemes = _redditFetchService.GetRedditModelMeme();

            _logger.LogInformation("Received reddit meme");

            var filteredMeme = _redditFilterService.RedditFilter(redditMemes);

            _logger.LogInformation("Filtered reddit meme");

            var mappedMeme = _redditMapperService.RedditModelToMeme(filteredMeme);

            _logger.LogInformation("Mapped to meme model");

            return mappedMeme;

        }
    }
}
