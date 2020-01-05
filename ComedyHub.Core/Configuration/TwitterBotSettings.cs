using ComedyHub.Core.Configuration.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Configuration
{
    public class TwitterBotSettings : ITwitterBotSettings
    {
        public string BotScreenName { get; set; }
        public int NumStatusToFetch { get; set; }
    }
}
