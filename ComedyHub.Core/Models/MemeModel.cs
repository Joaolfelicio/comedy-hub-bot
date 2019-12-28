using ComedyHub.Core.Infrastructure.NineGagModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Models
{
    public class MemeModel
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string MediaFile { get; set; }
        public bool Nsfw { get; set; }
        public int UpVoteCount { get; set; }
        public int DownVoteCount { get; set; }
        public string ImageUrl { get; set; }
        public int CommentsCount { get; set; }
        public List<string> Tags { get; set; }
        public string Provider { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
