using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
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
    public class NineGagMapperService : INineGagMapperService
    {
        private readonly IMapperService _mapperService;

        public NineGagMapperService(IMapperService mapperService)
        {
            _mapperService = mapperService;
        }

        public List<MemeModel> NineGagModelToMemes(NineGagModel nineGagModel)
        {
            var posts = nineGagModel.Data.Posts;

            // Unix Epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var memeModels = new List<MemeModel>();

            foreach (var post in posts)
            {
                var tags = new List<string>();

                foreach (var tag in post.Tags)
                {
                    tags.Add(tag.Key.Replace(" ", ""));
                }

                var fileExtension = Path.GetExtension(post.Images.Image460.Url);

                var meme = new MemeModel()
                {
                    Id = post.Id,
                    Title = HttpUtility.HtmlDecode(post.Title),
                    ImageUrl = post.Images.Image460.Url,
                    FileExtension = fileExtension,
                    Url = post.Url,
                    Tags = tags,
                    PublishedDate = dateTime.AddSeconds(post.CreationTs),
                    Nsfw = post.Nsfw == 0 ? false : true,
                    UpVoteCount = post.UpVoteCount,
                    DownVoteCount = post.DownVoteCount,
                    CommentsCount = post.CommentsCount,
                    Provider = MemeProvider.NineGag,
                    MediaType = post.Type
                };
                memeModels.Add(meme);
            }
                memeModels = _mapperService.MapToMemeModels(memeModels);

                return memeModels;
        }
    }
}
