using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.NineGagModels
{
    public class NGPost
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Nsfw { get; set; }
        public int UpVoteCount { get; set; }
        public int DownVoteCount { get; set; }
        public long CreationTs { get; set; }
        public NGImages Images { get; set; }
        public int CommentsCount { get; set; }
        public NGPostSection PostSection { get; set; }
        public List<NGTag> Tags { get; set; }
        public string DescriptionHtml { get; set; }
    }
}
