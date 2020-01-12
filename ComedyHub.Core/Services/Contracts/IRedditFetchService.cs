using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    public interface IRedditFetchService
    {
        List<Post> GetRedditModelMeme();
    }
}
