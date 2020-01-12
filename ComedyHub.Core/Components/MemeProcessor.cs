using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Configuration;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
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
        private readonly IRedditComponent _redditComponent;

        public MemeProcessor(IApplicationSettings applicationSettings,
                             INineGagComponent nineGagComponent,
                             IRedditComponent redditComponent)
        {
            _applicationSettings = applicationSettings;
            _nineGagComponent = nineGagComponent;
            _redditComponent = redditComponent;
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
                case Constants.MemeProvider.NineGag:
                    return await _nineGagComponent.GetNineGagMeme();

                case Constants.MemeProvider.Reddit:
                    return _redditComponent.GetRedditMeme();

                default:
                    return await _nineGagComponent.GetNineGagMeme();
            }

        }
    }
}
