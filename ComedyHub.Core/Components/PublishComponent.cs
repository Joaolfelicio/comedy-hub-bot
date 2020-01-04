using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Models;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Components
{
    public class PublishComponent : IPublishComponent
    {
        private readonly IPublishTwitterService _publishTwitterService;

        public PublishComponent(IPublishTwitterService publishTwitterService)
        {
            _publishTwitterService = publishTwitterService;
        }
        public PublishedModel PublishMeme(MemeModel memeModel)
        {
            return _publishTwitterService.PublishTwitter(memeModel);
        }
    }
}
