using ComedyHub.Core.Helpers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;

namespace ComedyHub.Core.Helpers
{
    public class TwitterAuth : ITwitterAuth
    {
        public void SetTwitterAuth()
        {
            Auth.SetUserCredentials(PrivateTokens.CONSUMER_KEY_TWITTER, PrivateTokens.CONSUMER_SECRET_TWITTER,
                                    PrivateTokens.ACCESS_TOKEN_TWITTER, PrivateTokens.ACCESS_TOKEN_SECRET_TWITTER);
        }
    }
}
