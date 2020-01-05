using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Model.Notification.TelegramMessage
{
    public class TelegramTextMessage
    {
        [JsonProperty("chat_id")]
        public int ChatId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("parse_mode")]
        public string ParseMode { get; set; }
    }
}
