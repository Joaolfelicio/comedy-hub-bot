using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ComedyHub.Core.Services
{
    public class NineGagMapperService : INineGagMapperService
    {
        public MemeModel NineGagModelToMeme(Post post)
        {
            var tags = new List<string>();

            foreach (var tag in post.Tags)
            {
                tags.Add(tag.Key.Replace(" ", ""));
            }

            // Unix Epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            
            return new MemeModel()
            {
                Id = post.Id,
                Title = HttpUtility.HtmlDecode(post.Title),
                ImageUrl = post.Images.Image460.Url,
                MediaFile = post.Type,
                Url = post.Url,
                Tags = tags,
                PublishedDate = dateTime.AddSeconds(post.CreationTs),
                Nsfw = post.Nsfw == 0 ? false : true,
                UpVoteCount = post.UpVoteCount,
                DownVoteCount = post.DownVoteCount,
                CommentsCount = post.CommentsCount,
                Provider = Constants.MemeProvider.NineGag
            };
        }
    }
}
