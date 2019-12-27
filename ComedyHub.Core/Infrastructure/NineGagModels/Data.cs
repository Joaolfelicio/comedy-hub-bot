using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.NineGagModels
{
    public class Data
    {
        public List<Post> Posts { get; set; }
        public Group Group { get; set; }
        public List<Tag> Tags { get; set; }
        public List<FeaturedAd> FeaturedAds { get; set; }
        public string NextCursor { get; set; }
    }
}
