using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using ComedyHub.Core.Constants;
using ComedyHub.Core.Configuration.Contracts;
using System.Linq;

namespace ComedyHub.Core.Services
{
    public class RedditMapperService : IRedditMapperService
    {
        private readonly IMapperService _mapperService;
        private readonly IApplicationSettings _applicationSettings;

        public RedditMapperService(IMapperService mapperService,
                                   IApplicationSettings applicationSettings)
        {
            _mapperService = mapperService;
            _applicationSettings = applicationSettings;
        }

        public List<MemeModel> RedditModelToMemes(List<Post> redditPosts)
        {
            var mappedMemes = new List<MemeModel>();
            var imageExtensionsSupported = _applicationSettings.SupportedImageExtensions.Split(';').ToList();

            foreach (var post in redditPosts)
            {
                var fileExtension = Path.GetExtension(post.Listing.URL);

                var meme = new MemeModel()
                {
                    Id = post.Id,
                    CommentsCount = post.Listing.NumComments,
                    DownVoteCount = post.DownVotes,
                    Title = HttpUtility.HtmlDecode(post.Title),
                    Nsfw = post.NSFW,
                    ImageUrl = post.Listing.URL,
                    PublishedDate = post.Created,
                    UpVoteCount = post.UpVotes,
                    FileExtension = fileExtension,
                    Url = post.Permalink,
                    Provider = MemeProvider.Reddit,
                    MediaType = imageExtensionsSupported.Contains(fileExtension) ? MediaType.MediaFilePhoto : MediaType.MediaFileAnimated
                };
             mappedMemes.Add(meme);
            }

            //Common mapping method between the memes services
            mappedMemes = _mapperService.MapToMemeModels(mappedMemes);

            return mappedMemes;
        }
    }
}
