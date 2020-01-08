using ComedyHub.Core.Auth.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;
using ComedyHub.Core.Auth;

namespace ComedyHub.Core.Auth
{
    public class TwitterAuth : ITwitterAuth
    {
        public void SetTwitterAuth()
        {
            
            Auth.SetUserCredentials(ConsumerToken.CONSUMER_KEY_TWITTER, PrivateTokens.CONSUMER_SECRET_TWITTER,
                                    PrivateTokens.ACCESS_TOKEN_TWITTER, PrivateTokens.ACCESS_TOKEN_SECRET_TWITTER);
        }
    }
}
