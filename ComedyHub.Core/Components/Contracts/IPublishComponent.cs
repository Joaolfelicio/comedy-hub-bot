using ComedyHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Components.Contracts
{
    public interface IPublishComponent
    {
        void PublishMeme(MemeModel memeModel);
    }
}
