using ComedyHub.Core.Auth.Contracts;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using ComedyHub.Core.Services.Contracts;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Tweetinvi;

namespace ComedyHub.Core.Services
{
    public class FilterService : IFilterService
    {
        private readonly ITwitterBotSettings _twitterBotSettings;
        private readonly ITwitterAuth _twitterAuth;

        public FilterService(ITwitterBotSettings twitterBotSettings,
                             ITwitterAuth twitterAuth)
        {
            _twitterBotSettings = twitterBotSettings;
            _twitterAuth = twitterAuth;
        }

        public T GetRandomPost<T>(List<T> posts)
        {
            var random = new Random();
            var randomPostIndex = random.Next(posts.Count);

            return posts[randomPostIndex];
        }

        public bool HasMemeAlreadyPosted(string memeTitle)
        {

            var cleanMemeTitle = HttpUtility.HtmlDecode(memeTitle);

            string botScreenName = _twitterBotSettings.BotScreenName;
            int numberStatusToFetch = _twitterBotSettings.NumStatusToFetch;

            //Set authorization on twitter
            _twitterAuth.SetTwitterAuth();

            var lastTweets = Timeline.GetUserTimeline(botScreenName, numberStatusToFetch);

            foreach (var postedTweet in lastTweets)
            {
                if (postedTweet.Text == cleanMemeTitle)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
