using ComedyHub.Core.Auth.Contracts;
using ComedyHub.Core.Components.Contracts;
using Microsoft.Extensions.Logging;
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
        private readonly INotificationComponent _notificationComponent;
        private readonly ILogger<MemeOrchestrator> _logger;

        public MemeOrchestrator(IMemeProcessor memeProcessor,
                                IPublishComponent publishComponent,
                                INotificationComponent notificationComponent,
                                ILogger<MemeOrchestrator> logger)
        {
            _memeProcessor = memeProcessor;
            _publishComponent = publishComponent;
            _notificationComponent = notificationComponent;
            _logger = logger;
        }

        public async Task Process()
        {
            try
            {
                var meme = await _memeProcessor.ProcessMeme();

                var publishedObj = _publishComponent.PublishMeme(meme);

                _logger.LogInformation("Sucessfully published meme");

                await _notificationComponent.SendSucessfulNotification(publishedObj);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to process meme");

                await _notificationComponent.SendFailureNotification(exception);

                throw;
            }
        }
    }
}
