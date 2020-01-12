﻿using ComedyHub.Core.Services.Contracts;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class RedditFilterService : IRedditFilterService
    {
        private readonly IFilterService _filterService;

        public RedditFilterService(IFilterService filterService)
        {
            _filterService = filterService;
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

            foreach (var post in posts)
            {
                if(_filterService.HasMemeAlreadyPosted(post.Title) == false)
                {
                    distinctPosts.Add(post);
                }
            }

            return distinctPosts;
        }
    }
}
