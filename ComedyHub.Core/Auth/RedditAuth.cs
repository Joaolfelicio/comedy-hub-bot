using ComedyHub.Core.Auth.Contracts;
using Reddit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Auth
{
    public class RedditAuth : IRedditAuth
    {
        public RedditClient SetRedditAuth()
        {
            return new RedditClient(AppInfo.REDDIT_APP_ID, ConsumerToken.CONSUMER_REFRESH_REDDIT, ConsumerToken.CONSUMER_SECRET_REDDIT);
        }
    }
}
