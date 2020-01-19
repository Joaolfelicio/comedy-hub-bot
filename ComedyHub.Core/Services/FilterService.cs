using ComedyHub.Core.Auth.Contracts;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Tweetinvi;
using ComedyHub.Core.Constants;

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

        public MemeModel FilterMemes(List<MemeModel> posts)
        {
            var postsWithImage = RemovePostsWithoutImage(posts);

            var distinctPosts = RemoveDuplicates(postsWithImage);

            var randomFilteredMeme = GetRandomPost(distinctPosts);

            return randomFilteredMeme;
        }

        private MemeModel GetRandomPost(List<MemeModel> posts)
        {
            var random = new Random();
            var randomPostIndex = random.Next(posts.Count);

            return posts[randomPostIndex];
        }

        private List<MemeModel> RemoveDuplicates(List<MemeModel> posts)
        {
            string botScreenName = _twitterBotSettings.BotScreenName;
            int numberStatusToFetch = _twitterBotSettings.NumStatusToFetch;

            var notDuplicatedPosts = new List<MemeModel>(posts);

            //Set authorization on twitter
            _twitterAuth.SetTwitterAuth();

            var lastTweets = Timeline.GetUserTimeline(botScreenName, numberStatusToFetch);

            foreach (var post in posts)
            {
                foreach (var postedTweet in lastTweets)
                {
                    if (postedTweet.Text == post.Title)
                    {
                        notDuplicatedPosts.Remove(post);
                        break;
                    }
                }
            }
            return notDuplicatedPosts;
        }

        private List<MemeModel> RemovePostsWithoutImage(List<MemeModel> posts)
        {
            var postsWithImage = new List<MemeModel>();

            foreach (var post in posts)
            {
                if (post.MediaType == MediaType.MediaFilePhoto)
                {
                    postsWithImage.Add(post);
                }
            }
            return postsWithImage;
        }
    }
}
