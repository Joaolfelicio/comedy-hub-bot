using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.Gateway.Contracts
{
    public interface IRedditGateway
    {
        List<Post> GetRedditMeme();
    }
}
