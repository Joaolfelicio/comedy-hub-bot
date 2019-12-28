using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.NineGagModels
{
    public class NGImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string WebpUrl { get; set; }
    }
}
