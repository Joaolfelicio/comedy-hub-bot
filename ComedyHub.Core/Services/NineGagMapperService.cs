using ComedyHub.Core.Helpers;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme;
using ComedyHub.Model.Meme.NineGagMeme;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class NineGagMapperService : INineGagMapperService
    {
        public MemeModel NineGagModelToMeme(Post ngPost)
        {
            var tags = new List<string>();

            foreach (var tag in ngPost.Tags)
            {
                tags.Add(tag.key.Replace(" ", ""));
            }

            // Unix Epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            
            return new MemeModel()
            {
                Id = ngPost.Id,
                Title = ngPost.Title,
                ImageUrl = ngPost.Images.Image460.Url,
                MediaFile = ngPost.Type,
                Url = ngPost.Url,
                Tags = tags,
                PublishedDate = dateTime.AddSeconds(ngPost.CreationTs),
                Nsfw = ngPost.Nsfw == 0 ? false : true,
                UpVoteCount = ngPost.UpVoteCount,
                DownVoteCount = ngPost.DownVoteCount,
                CommentsCount = ngPost.CommentsCount,
                Provider = Constants.NineGag
            };
        }
    }
}
