using ComedyHub.Core.Helpers;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Meme.NineGagMeme;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class NineGagFilterService : INineGagFilterService
    {
        public Post NineGagFilter(NineGagModel nineGag)
        {
            var posts = new List<Post>();

            foreach (var post in nineGag.Data.Posts)
            {
                if(post.Type == Constants.MediaFilePhoto)
                {
                    posts.Add(post);
                }
            }

            Random random = new Random();
            int randomNum = random.Next(posts.Count);

            Post randomPost = posts[randomNum];
            
            return randomPost;
        }
    }
}
