using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
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

        public NineGagComponent(INineGagFetchService nineGagFetchService,
                                INineGagFilterService nineGagFilterService,
                                INineGagMapperService nineGagMapperService)
        {
            _nineGagFetchService = nineGagFetchService;
            _nineGagFilterService = nineGagFilterService;
            _nineGagMapperService = nineGagMapperService;
        }
        public async Task<MemeModel> GetNineGagMeme()
        {
            var nineGagModels = await _nineGagFetchService.GetNineGagModelMeme();

            var nineGagPostModel = _nineGagFilterService.NineGagFilter(nineGagModels);

            var memeModel = _nineGagMapperService.NineGagModelToMeme(nineGagPostModel);

            return memeModel;
        }
    }
}
