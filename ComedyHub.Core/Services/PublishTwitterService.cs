using ComedyHub.Core.Services.Contracts;
using ComedyHub.Core;
using ComedyHub.Model.Meme;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using ComedyHub.Core.Auth.Contracts;

namespace ComedyHub.Core.Services
{
    public class PublishTwitterService : IPublishTwitterService
    {

        public PublishedModel PublishTwitter(MemeModel memeModel)
        { 
            var imageList = new List<byte[]>();

            var title = memeModel.Title;

            foreach (var tag in memeModel.Tags)
            {
                title = title + " #" + tag;
            }

            using (var webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(memeModel.ImageUrl);
                imageList.Add(imageBytes);
            }

            var tweetParameters = new PublishTweetOptionalParameters()
            {
                PossiblySensitive = memeModel.Nsfw,
                MediaBinaries = imageList
            };

            var tweetPublished = Tweet.PublishTweet(title, tweetParameters);

            return new PublishedModel()
            {
                PublishedURL = tweetPublished.Url,
                Message = $"Successfully published meme.",
                MemeProvider = Constants.MemeProvider.NineGag,
                PublishedAt = "Twitter",
                ImageUrl = memeModel.ImageUrl
            };
        }
    }
}
