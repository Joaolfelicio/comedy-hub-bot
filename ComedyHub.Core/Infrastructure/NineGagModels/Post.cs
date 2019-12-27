using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.NineGagModels
{
    public class Post
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public bool Nsfw { get; set; }
        public int UpVoteCount { get; set; }
        public int DownVoteCount { get; set; }
        public long CreationTs { get; set; }
        public bool Promoted { get; set; }
        public bool IsVoteMasked { get; set; }
        public bool HasLongPostCover { get; set; }
        public List<Images> Images { get; set; }
        public string SourceDomain { get; set; }
        public string SourceUrl { get; set; }
        public int CommentsCount { get; set; }
        public PostSection PostSection { get; set; }
        public List<Tag> Tags { get; set; }
        public string DescriptionHtml { get; set; }
    }
}
