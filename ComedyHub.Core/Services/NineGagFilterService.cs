using ComedyHub.Core.Auth.Contracts;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;
using ComedyHub.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweetinvi;

namespace ComedyHub.Core.Services
{
    public class NineGagFilterService : INineGagFilterService
    {
        private readonly IFilterService _filterService;

        public NineGagFilterService(IFilterService filterService)
        {
            _filterService = filterService;
        }

        public NineGagPost NineGagFilter(NineGagModel nineGag)
        {
            var posts = RemoveDuplicates(nineGag);

            var postsMediaTypePhoto = KeepPostsMediaTypePhoto(posts);

            var randomCleanPost = postsMediaTypePhoto[_filterService.GetRandomPost(postsMediaTypePhoto)];

            return randomCleanPost;
        }

        private List<NineGagPost> RemoveDuplicates(NineGagModel nineGag)
        {
            var posts = new List<NineGagPost>();

                foreach (var post in nineGag.Data.Posts)
                {
                    var title = post.Title;

                    // Add the tags to the title so we are able to compare
                    foreach (var tag in post.Tags)
                    {
                        var cleanTag = tag.Key.Replace(" ", "");

                        title = title + " #" + cleanTag;
                    }

                    // Decode HTML code to normal text
                    if (_filterService.HasMemeAlreadyPosted(title))
                    {
                        posts.Add(post);
                        break;
                    }
                }
            return posts;
        }

        private List<NineGagPost> KeepPostsMediaTypePhoto(List<NineGagPost> posts)
        {
            var imagesPosts = new List<NineGagPost>(posts);

            foreach (var post in posts)
            {
                if (post.Type != Constants.MediaType.MediaFilePhoto)
                {
                    imagesPosts.Remove(post);
                }
            }
            return imagesPosts;
        }
    }

}
