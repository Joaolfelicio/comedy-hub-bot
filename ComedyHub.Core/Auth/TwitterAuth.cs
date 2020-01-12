namespace ComedyHub.Core.Auth
{
    using ComedyHub.Core.Auth.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Tweetinvi;

    public class TwitterAuth : ITwitterAuth
    {
        public void SetTwitterAuth()
        {

            Auth.SetUserCredentials(ConsumerToken.CONSUMER_KEY_TWITTER, ConsumerToken.CONSUMER_SECRET_TWITTER,
                                    AccessToken.ACCESS_TOKEN_TWITTER, AccessToken.ACCESS_TOKEN_SECRET_TWITTER);
        }
    }
}
