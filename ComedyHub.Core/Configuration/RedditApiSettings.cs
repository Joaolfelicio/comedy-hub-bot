using ComedyHub.Core.Configuration.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Configuration
{
    public class RedditApiSettings : IRedditApiSettings
    {
        public string SubredditToFetch { get; set; }

        public int NumPostsToReceive {get; set; }
}
}
