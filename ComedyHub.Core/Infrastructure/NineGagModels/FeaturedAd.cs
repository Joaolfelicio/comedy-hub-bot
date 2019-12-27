using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.NineGagModels
{
    [JsonObject(MemberSerialization.Fields)]
    public class FeaturedAd
    {
        public int Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Render { get; set; }
        public string AdTagUrl { get; set; }
        public List<PlayList> Playlist { get; set; }
        public string ShowTitle { get; set; }
        public string EnableVideoTitleClick { get; set; }
        public string Url { get; set; }
    }
}
