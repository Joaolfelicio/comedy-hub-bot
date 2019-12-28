using ComedyHub.Core.Infrastructure.NineGagModels;
using ComedyHub.Core.Infrastructure.NineGagModels.Models;
using ComedyHub.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class NineGagFilterService : INineGagFilterService
    {
        public NGPost NineGagFilter(NineGagModel nineGag)
        {
            var posts = new List<NGPost>();

            foreach (var ngPost in nineGag.Data.Posts)
            {
                if(ngPost.Type == "Photo")
                {
                    posts.Add(ngPost);
                }
            }

            Random random = new Random();
            int randomNum = random.Next(posts.Count - 1);

            NGPost randomPost = posts[randomNum];
            
            return randomPost;
        }
    }
}
