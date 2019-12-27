using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Configuration;
using ComedyHub.Core.Infrastructure.NineGagModels.Models;
using ComedyHub.Core.Models;
using ComedyHub.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components
{
    public class MemeFetcher : IMemeFetcher
    {

        private readonly INineGagMemeService _nineGagMemeService;
        private readonly IApplicationSettings _applicationSettings;

        public MemeFetcher(INineGagMemeService nineGagMemeService, IApplicationSettings applicationSettings)
        {
            _nineGagMemeService = nineGagMemeService;
            _applicationSettings = applicationSettings;
        }
        public async Task<NineGagModel> GetMeme()
        {
            return await GetRandomMemeService();
        }

        private async Task<NineGagModel> GetRandomMemeService()
        {
            string[] servicesToFetch = _applicationSettings.ServicesToFetch.Split(';') ;

            Random random = new Random();

            int randomNum = random.Next(servicesToFetch.Length);

            switch(servicesToFetch[randomNum])
            {
                case "NineGag":
                    return await _nineGagMemeService.GetNineGagMeme();

                case "Reddit":
                    return await _nineGagMemeService.GetNineGagMeme();

                default:
                    return await _nineGagMemeService.GetNineGagMeme();
            }

        }
    }
}
