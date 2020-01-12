using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels
{
    public class Post
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Nsfw { get; set; }
        public int UpVoteCount { get; set; }
        public int DownVoteCount { get; set; }
        public long CreationTs { get; set; }
        public Images Images { get; set; }
        public int CommentsCount { get; set; }
        public PostSection PostSection { get; set; }
        public List<Tag> Tags { get; set; }
        public string DescriptionHtml { get; set; }
    }
}
