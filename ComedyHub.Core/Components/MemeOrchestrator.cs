using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components
{
    public class MemeOrchestrator : IMemeOrchestrator
    {
        private readonly IMemeProcessor _memeProcessor;
        private readonly IPublishComponent _publishComponent;

        public MemeOrchestrator(IMemeProcessor memeProcessor,
                                IPublishComponent publishComponent)
        {
            _memeProcessor = memeProcessor;
            _publishComponent = publishComponent;
        }

        public async Task Process()
        {
            try
            {
                var meme = await _memeProcessor.ProcessMeme();

                _publishComponent.PublishMeme(meme);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
