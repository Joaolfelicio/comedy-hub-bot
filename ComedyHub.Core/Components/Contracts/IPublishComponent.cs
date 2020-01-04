using ComedyHub.Core.Models;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Components.Contracts
{
    public interface IPublishComponent
    {
        PublishedModel PublishMeme(MemeModel memeModel);
    }
}
