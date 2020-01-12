using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using ComedyHub.Core.Services.Contracts;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class RedditFetchService : IRedditFetchService
    {
        private readonly IRedditGateway _redditGateway;

        public RedditFetchService(IRedditGateway redditGateway)
        {
            _redditGateway = redditGateway;
        }
        public List<Post> GetRedditModelMeme()
        {
            return _redditGateway.GetRedditMeme();
        }
    }
}
