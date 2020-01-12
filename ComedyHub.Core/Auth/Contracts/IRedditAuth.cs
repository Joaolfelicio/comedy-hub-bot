using Reddit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Auth.Contracts
{
    public interface IRedditAuth
    {
        RedditClient SetRedditAuth();
    }
}
