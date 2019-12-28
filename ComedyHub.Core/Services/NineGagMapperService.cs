using ComedyHub.Core.Helpers;
using ComedyHub.Core.Infrastructure.NineGagModels;
using ComedyHub.Core.Models;
using ComedyHub.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class NineGagMapperService : INineGagMapperService
    {
        public MemeModel NineGagModelToMeme(NGPost ngPost)
        {
            //TODO Fix this, its sending the ascii
            var test = "My father &#039;s Kryptonite";

            byte[] bytesTitle = Encoding.ASCII.GetBytes(test);

            string titleDecoded = Encoding.ASCII.GetString(bytesTitle);

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
                Title = titleDecoded,
                ImageUrl = ngPost.Images.Image700.Url,
                MediaFile = ngPost.Type,
                Url = ngPost.Url,
                Tags = tags,
                PublishedDate = dateTime.AddSeconds(ngPost.CreationTs),
                Nsfw = ngPost.Nsfw == 0 ? false : true,
                UpVoteCount = ngPost.UpVoteCount,
                DownVoteCount = ngPost.DownVoteCount,
                CommentsCount = ngPost.CommentsCount,
                Provider = Constants.ProviderNineGag
            };
        }
    }
}
