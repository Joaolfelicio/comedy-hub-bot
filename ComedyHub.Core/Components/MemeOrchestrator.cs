﻿using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Helpers.Contracts;
using NLog;
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
        private readonly ITwitterAuth _twitterAuth;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ITwitterAuth TwitterAuth { get; }

        public MemeOrchestrator(IMemeProcessor memeProcessor,
                                IPublishComponent publishComponent,
                                INotificationComponent notificationComponent,
                                ITwitterAuth twitterAuth)
        {
            _memeProcessor = memeProcessor;
            _publishComponent = publishComponent;
            _notificationComponent = notificationComponent;
            _twitterAuth = twitterAuth;
        }

        public async Task Process()
        {
            try
            {
                _twitterAuth.SetTwitterAuth();

                var meme = await _memeProcessor.ProcessMeme();

                var publishedObj = _publishComponent.PublishMeme(meme);

                await _notificationComponent.SendSucessfulNotification(publishedObj);

            }
            catch (Exception exception)
            {
                logger.Error(exception);
                await _notificationComponent.SendFailureNotification(exception);
                throw;
            }
        }
    }
}
