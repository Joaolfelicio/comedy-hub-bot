using ComedyHub.Core.Helpers;
using ComedyHub.Core.Models;
using ComedyHub.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace ComedyHub.Core.Services
{
    public class PublishTwitterService : IPublishTwitterService
    {
        public void PublishTwitter(MemeModel memeModel)
        {
            var imageList = new List<byte[]>();

            var title = memeModel.Title;

            foreach (var tag in memeModel.Tags)
            {
                title = title + " #" + tag;
            }

            Auth.SetUserCredentials(PrivateTokens.CONSUMER_KEY, PrivateTokens.CONSUMER_SECRET,
                                    PrivateTokens.ACCESS_TOKEN, PrivateTokens.ACCESS_TOKEN_SECRET);

            using (var webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(memeModel.ImageUrl);

                imageList.Add(imageBytes);

            }

            var tweetParameters = new PublishTweetOptionalParameters()
            {
                PossiblySensitive = memeModel.Nsfw,
                MediaBinaries = imageList,
                
            };

            Tweet.PublishTweet(title, tweetParameters);
        }
    }
}
