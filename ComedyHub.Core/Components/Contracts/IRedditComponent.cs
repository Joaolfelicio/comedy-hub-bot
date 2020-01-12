using ComedyHub.Model.Meme;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Components.Contracts
{
    public interface IRedditComponent
    {
        MemeModel GetRedditMeme();
    }
}
