using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Services.Contracts;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class RedditFilterService : IRedditFilterService
    {
        private readonly IFilterService _filterService;
        private readonly IApplicationSettings _applicationSettings;

        public RedditFilterService(IFilterService filterService,
                                   IApplicationSettings applicationSettings)
        {
            _filterService = filterService;
            _applicationSettings = applicationSettings;
        }

        public Post RedditFilter(List<Post> posts)
        {
            var distinctPosts = RemoveDuplicates(posts);

            var randomCleanPost = distinctPosts[_filterService.GetRandomPost(distinctPosts)];

            return randomCleanPost;
        }

        private List<Post> RemoveDuplicates(List<Post> posts)
        {
            var distinctPosts = new List<Post>();


            //The default tags on the appsettings
            var defaultTags = _applicationSettings.DefaultTags.Split(';');

            foreach (var post in posts)
            {
                var tags = new List<string>(defaultTags);

                var title = post.Title;

                // Add the tags to the title so we are able to compare
                foreach (var tag in tags)
                {
                    var cleanTag = tag.Replace(" ", "");

                    title = title + " #" + cleanTag;
                }

                if (_filterService.HasMemeAlreadyPosted(title) == false)
                {
                    distinctPosts.Add(post);
                }
            }
            return distinctPosts;
        }
    }
}
