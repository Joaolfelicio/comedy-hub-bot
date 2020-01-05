using ComedyHub.Model.Meme;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    public interface IPublishTwitterService
    {
        PublishedModel PublishTwitter(MemeModel memeModel);
    }
}
