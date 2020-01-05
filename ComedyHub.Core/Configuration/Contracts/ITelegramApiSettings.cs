using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Configuration.Contracts
{
    public interface ITelegramApiSettings
    {
        string Url { get; }
        int ReceiverId { get; }
        string ParseMode { get; }
    }
}
