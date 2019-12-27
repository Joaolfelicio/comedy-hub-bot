using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.NineGagModels
{
    [JsonObject(MemberSerialization.Fields)]
    public class Group
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string OgImageUrl { get; set; }
        public string OgWebpUrl { get; set; }
        public bool UserUploadEnabled { get; set; }
        public bool IsSensitive { get; set; }
        public string Location { get; set; }
    }
}
