using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Configuration;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Infrastructure.NineGagModels.Models;
using ComedyHub.Core.Models;
using ComedyHub.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components
{
    public class MemeProcessor : IMemeProcessor
    {

        private readonly INineGagFetchService _nineGagFetchService;
        private readonly IApplicationSettings _applicationSettings;
        private readonly INineGagComponent _nineGagComponent;

        public MemeProcessor(INineGagFetchService nineGagFetchService, 
                             IApplicationSettings applicationSettings,
                             INineGagComponent nineGagComponent)
        {
            _nineGagFetchService = nineGagFetchService;
            _applicationSettings = applicationSettings;
            _nineGagComponent = nineGagComponent;
        }


        public async Task<MemeModel> ProcessMeme()
        {
            return await ProcessRandomService();
        }


        private async Task<MemeModel> ProcessRandomService()
        {
            var servicesToFetch = _applicationSettings.ServicesToFetch.Split(';');

            Random random = new Random();

            int randomNum = random.Next(servicesToFetch.Length - 1);

            switch (servicesToFetch[randomNum])
            {
                case "NineGag":
                    return await _nineGagComponent.GetNineGagMeme();

                case "Reddit":
                    return await _nineGagComponent.GetNineGagMeme();

                default:
                    return await _nineGagComponent.GetNineGagMeme();
            }

        }
    }
}
