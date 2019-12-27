using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.NineGagModels
{
    [JsonObject(MemberSerialization.Fields)]
    public class PlayList
    {
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public string Url { get; set; }
    }
}
