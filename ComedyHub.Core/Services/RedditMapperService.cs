using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ComedyHub.Core.Services
{
    public class RedditMapperService : IRedditMapperService
    {
        private readonly IMapperService _mapperService;

        public RedditMapperService(IMapperService mapperService)
        {
            _mapperService = mapperService;
        }

        public MemeModel RedditModelToMeme(Post redditPost)
        {
            var meme = new MemeModel()
            {
                Id = redditPost.Id,
                CommentsCount = redditPost.Listing.NumComments,
                DownVoteCount = redditPost.DownVotes,
                Title = HttpUtility.HtmlDecode(redditPost.Title),
                Nsfw = redditPost.NSFW,
                ImageUrl = redditPost.Listing.URL,
                PublishedDate = redditPost.Created,
                UpVoteCount = redditPost.UpVotes,
                MediaFile = Constants.MediaType.MediaFilePhoto,
                Url = redditPost.Permalink,
                Provider = Constants.MemeProvider.Reddit
            };

            meme = _mapperService.MapToMemeModel(meme);

            return meme;
        }
    }
}
