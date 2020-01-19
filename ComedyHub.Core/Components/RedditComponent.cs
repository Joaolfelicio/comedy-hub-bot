using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components
{
    public class RedditComponent : IRedditComponent
    {
        private readonly IRedditFetchService _redditFetchService;
        private readonly IRedditMapperService _redditMapperService;
        private readonly IFilterService _filterService;
        private readonly ILogger<RedditComponent> _logger;

        public RedditComponent(IRedditFetchService redditFetchService,
                               IRedditMapperService redditMapperService,
                               IFilterService filterService,
                               ILogger<RedditComponent> logger)
        {
            _redditFetchService = redditFetchService;
            _redditMapperService = redditMapperService;
            _filterService = filterService;
            _logger = logger;
        }
        public async Task<MemeModel> GetRedditMeme()
        {
            var redditMemes = _redditFetchService.GetRedditModelMeme();

            _logger.LogInformation("Received reddit memes");

            var mappedMemes = _redditMapperService.RedditModelToMemes(redditMemes);

            _logger.LogInformation("Mapped to memes models");

            var filteredMeme = await _filterService.FilterMemes(mappedMemes);

            _logger.LogInformation("Filtered memes to meme");


            return filteredMeme;

        }
    }
}
