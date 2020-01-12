using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class RedditMapperService : IRedditMapperService
    {
        public MemeModel RedditModelToMeme(Post redditPost)
        {
            return new MemeModel()
            {
                Id = redditPost.Id,
                CommentsCount = redditPost.Listing.NumComments,
                DownVoteCount = redditPost.DownVotes,
                Title = redditPost.Title,
                Nsfw = redditPost.NSFW,
                ImageUrl = redditPost.Listing.URL,
                PublishedDate = redditPost.Created,
                UpVoteCount = redditPost.UpVotes,
                MediaFile = Constants.MediaType.MediaFilePhoto,
                Provider = Constants.MemeProvider.Reddit,
                Url = redditPost.Permalink
            };
        }
    }
}
