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
        private readonly IApplicationSettings _applicationSettings;

        public NineGagFilterService(IFilterService filterService,
                                    IApplicationSettings applicationSettings)
        {
            _filterService = filterService;
            _applicationSettings = applicationSettings;
        }

        public NineGagPost NineGagFilter(NineGagModel nineGag)
        {
            var posts = RemoveDuplicates(nineGag);

            var postsMediaTypePhoto = KeepPostsMediaTypePhoto(posts);

            var randomCleanPost = _filterService.GetRandomPost(postsMediaTypePhoto);

            return randomCleanPost;
        }

        private List<NineGagPost> RemoveDuplicates(NineGagModel nineGag)
        {
            var posts = new List<NineGagPost>();

            //The default tags on the appsettings
            var defaultTags = _applicationSettings.DefaultTags.Split(';');


            foreach (var post in nineGag.Data.Posts)
            {
                var tags = new List<string>(defaultTags);

                var title = post.Title;

                // Add the tags to the tags list
                foreach (var tag in post.Tags)
                {
                    tags.Add(tag.Key);
                }

                // Add the tags to the title so we are able to compare
                foreach (var tag in tags)
                {
                    var cleanTag = tag.Replace(" ", "");

                    title = title + " #" + cleanTag;
                }

                // Decode HTML code to normal text
                if (_filterService.HasMemeAlreadyPosted(title) == false)
                {
                    posts.Add(post);
                }
            }
            return posts;
        }

        private List<NineGagPost> KeepPostsMediaTypePhoto(List<NineGagPost> posts)
        {
            var imagesPosts = new List<NineGagPost>();

            foreach (var post in posts)
            {
                if (post.Type == Constants.MediaType.MediaFilePhoto)
                {
                    imagesPosts.Add(post);
                }
            }
            return imagesPosts;
        }
    }

}
