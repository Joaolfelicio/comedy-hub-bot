using ComedyHub.Core.Auth;
using ComedyHub.Core.Auth.Contracts;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using Reddit;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Infrastructure.Gateway
{
    public class RedditGateway : IRedditGateway
    {
        private readonly IRedditApiSettings _redditApiSettings;
        private readonly IRedditAuth _redditAuth;

        public RedditGateway(IRedditApiSettings redditApiSettings,
                             IRedditAuth redditAuth)
        {
            _redditApiSettings = redditApiSettings;
            _redditAuth = redditAuth;
        }
        public List<Post> GetRedditMeme()
        {
            string subredditToFecth = _redditApiSettings.SubredditToFetch;
            int numPostsToReceive = _redditApiSettings.NumPostsToReceive;

            var redditApi = _redditAuth.SetRedditAuth();

            var askReddit = redditApi.Subreddit(subredditToFecth).About();
            var topPosts = askReddit.Posts.GetHot(limit: numPostsToReceive);

            return topPosts;
        }
    }
}
