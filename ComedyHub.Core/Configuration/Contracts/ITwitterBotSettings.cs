using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Configuration.Contracts
{
    public interface ITwitterBotSettings
    {
        string BotScreenName { get; }
        int NumStatusToFetch { get; }
    }
}
