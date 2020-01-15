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
        private readonly INineGagFilterService _nineGagFilterService;
        private readonly INineGagMapperService _nineGagMapperService;
        private readonly ILogger<NineGagComponent> _logger;

        public NineGagComponent(INineGagFetchService nineGagFetchService,
                                INineGagFilterService nineGagFilterService,
                                INineGagMapperService nineGagMapperService,
                                ILogger<NineGagComponent> logger)
        {
            _nineGagFetchService = nineGagFetchService;
            _nineGagFilterService = nineGagFilterService;
            _nineGagMapperService = nineGagMapperService;
            _logger = logger;
        }
        public async Task<MemeModel> GetNineGagMeme()
        {
            var nineGagModels = await _nineGagFetchService.GetNineGagModelMeme();

            _logger.LogInformation("Received nine gag meme");

            var nineGagPostModel = _nineGagFilterService.NineGagFilter(nineGagModels);

            _logger.LogInformation("Filtered nine gag meme");

            var memeModel = _nineGagMapperService.NineGagModelToMeme(nineGagPostModel);

            _logger.LogInformation("Mapped to meme model");

            return memeModel;
        }
    }
}
