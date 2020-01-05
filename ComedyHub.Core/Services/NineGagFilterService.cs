using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Helpers;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme.NineGagMeme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweetinvi;

namespace ComedyHub.Core.Services
{
    public class NineGagFilterService : INineGagFilterService
    {
        private readonly ITwitterBotSettings _twitterBotSettings;

        public NineGagFilterService(ITwitterBotSettings twitterBotSettings)
        {
            _twitterBotSettings = twitterBotSettings;
        }

        public Post NineGagFilter(NineGagModel nineGag)
        {

            var posts = RemoveDuplicates(nineGag);

            var postsMediaTypePhoto = KeepPostsMediaTypePhoto(posts);

            var randomCleanPost = GetRandomPost(postsMediaTypePhoto);

            return randomCleanPost;
        }

        private List<Post> RemoveDuplicates(NineGagModel nineGag)
        {
            var posts = new List<Post>(nineGag.Data.Posts);

            string botScreenName = _twitterBotSettings.BotScreenName;
            int numberStatusToFetch = _twitterBotSettings.NumStatusToFetch;

            var lastTweets = Timeline.GetUserTimeline(botScreenName, numberStatusToFetch);

            foreach (var postedTweet in lastTweets)
            {

                foreach (var post in posts)
                {
                    var title = post.Title;

                    // Add the tags to the title so we are able to compare
                    foreach (var tag in post.Tags)
                    {
                        var cleanTag = tag.key.Replace(" ", "");

                        title = title + " #" + cleanTag;
                    }

                    // Decode HTML code to normal text
                    if (postedTweet.Text == HttpUtility.HtmlDecode(title))
                    {
                        posts.Remove(post);
                        break;
                    }
                }
            }

            return posts;
        }

        private List<Post> KeepPostsMediaTypePhoto(List<Post> posts)
        {
            var imagesPosts = new List<Post>(posts);

            foreach (var post in posts)
            {
                if (post.Type != Constants.MediaFilePhoto)
                {
                    imagesPosts.Remove(post);
                }
            }
            return imagesPosts;
        }

        private Post GetRandomPost(List<Post> posts)
        {
            Random random = new Random();
            Post randomPost = new Post();

            int randomNum = random.Next(posts.Count);

            try
            {
                randomPost = posts[randomNum];
            }
            catch 
            {
                throw new Exception($"No memes to post, number of memes available after filtering: {posts.Count}");
            }

            return randomPost;
        }
    }

}
