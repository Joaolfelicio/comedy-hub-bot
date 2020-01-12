using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Configuration.Contracts
{
    public interface IRedditApiSettings
    {
        string SubredditToFetch { get; }
        int NumPostsToReceive { get; }
    }
}
