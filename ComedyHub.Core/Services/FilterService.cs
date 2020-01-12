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

        //TODO: Confirm if this is good
        public Tuple<NineGagPost, Post> GetRandomPost(List<NineGagPost> nineGagposts, List<Post> redditPosts)
        {
            var random = new Random();

            if (redditPosts == null)
            {
                return new Tuple<NineGagPost, Post>(nineGagposts[random.Next(nineGagposts.Count)], null);
            }
            else
            {
                return new Tuple<NineGagPost, Post>(null, redditPosts[random.Next(redditPosts.Count)]);
            }
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
