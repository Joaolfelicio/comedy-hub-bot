using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Infrastructure.NineGagModels
{
    public class NGData
    {
        public List<NGPost> Posts { get; set; }
        public string NextCursor { get; set; }
    }
}
