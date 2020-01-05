using ComedyHub.Core.Configuration.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Configuration
{
    public class TelegramApiSettings : ITelegramApiSettings
    {
        public string Url { get; set; }
        public int ReceiverId { get; set; }
        public string ParseMode { get; set; }
    }
}
