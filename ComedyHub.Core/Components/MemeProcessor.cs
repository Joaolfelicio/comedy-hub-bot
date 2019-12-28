using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Configuration;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Helpers;
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
        private readonly IApplicationSettings _applicationSettings;
        private readonly INineGagComponent _nineGagComponent;

        public MemeProcessor(IApplicationSettings applicationSettings,
                             INineGagComponent nineGagComponent)
        {
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

            int randomNum = random.Next(servicesToFetch.Length);

            switch (servicesToFetch[randomNum])
            {
                case Constants.ProviderNineGag:
                    return await _nineGagComponent.GetNineGagMeme();

                case "Reddit":
                    return await _nineGagComponent.GetNineGagMeme();

                default:
                    return await _nineGagComponent.GetNineGagMeme();
            }

        }
    }
}
