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
    public class NineGagComponent : INineGagComponent
    {
        private readonly INineGagFetchService _nineGagFetchService;
        private readonly IFilterService _filterService;
        private readonly INineGagMapperService _nineGagMapperService;
        private readonly ILogger<NineGagComponent> _logger;

        public NineGagComponent(INineGagFetchService nineGagFetchService,
                                IFilterService filterService,
                                INineGagMapperService nineGagMapperService,
                                ILogger<NineGagComponent> logger)
        {
            _nineGagFetchService = nineGagFetchService;
            _filterService = filterService;
            _nineGagMapperService = nineGagMapperService;
            _logger = logger;
        }
        public async Task<MemeModel> GetNineGagMeme()
        {
            var nineGagModels = await _nineGagFetchService.GetNineGagModelMeme();

            _logger.LogInformation("Received nine gag memes");

            var nineGagPostModel = _nineGagMapperService.NineGagModelToMemes(nineGagModels);

            _logger.LogInformation("Mapped to memes models");

            var memeModel = _filterService.FilterMemes(nineGagPostModel);

            _logger.LogInformation("Filtered memes models to meme models");

            return memeModel;
        }
    }
}
