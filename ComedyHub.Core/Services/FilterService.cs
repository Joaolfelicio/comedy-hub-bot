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
using System.Net.Http;
using System.Threading.Tasks;
using ComedyHub.Core.Infrastructure.Gateway.Contracts;

namespace ComedyHub.Core.Services
{
    public class FilterService : IFilterService
    {
        private readonly ITwitterBotSettings _twitterBotSettings;
        private readonly ITwitterAuth _twitterAuth;
        private readonly IApplicationSettings _applicationSettings;
        private readonly IContentGateway _contentGateway;

        public FilterService(ITwitterBotSettings twitterBotSettings,
                             ITwitterAuth twitterAuth,
                             IApplicationSettings applicationSettings,
                             IContentGateway contentGateway)
        {
            _twitterBotSettings = twitterBotSettings;
            _twitterAuth = twitterAuth;
            _applicationSettings = applicationSettings;
            _contentGateway = contentGateway;
        }

        public async Task<MemeModel> FilterMemes(List<MemeModel> posts)
        {
            var postsWithImage = RemovePostsWithoutImage(posts);

            var imagesWithSizeLimit = await RemoveImagesWithSizeLimit(postsWithImage);

            var distinctPosts = RemoveDuplicates(imagesWithSizeLimit);

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

        private async Task<List<MemeModel>> RemoveImagesWithSizeLimit(List<MemeModel> posts)
        {
            var sizeLimitBytes = _applicationSettings.SizeLimitMegaBytes * 1000000;

            var imagesWithSizeLimit = new List<MemeModel>();

            foreach (var post in posts)
            {
                var imageHeaders = await _contentGateway.GetContentHeaders(post.ImageUrl);

                if (sizeLimitBytes > imageHeaders.ContentLength)
                {
                    imagesWithSizeLimit.Add(post);
                }
            }
            return imagesWithSizeLimit;
        }
    }
}
