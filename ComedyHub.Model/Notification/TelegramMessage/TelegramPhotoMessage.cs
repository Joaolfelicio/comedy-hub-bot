using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Model.Notification.TelegramMessage
{
    public class TelegramPhotoMessage : TelegramMessage
    {
        [JsonProperty("chat_id")]
        public int ChatId { get; set; }
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("parse_mode")]
        public string ParseMode { get; set; }

        [JsonProperty("photo")]
        public string PhotoUrl { get; set; }
    }
}
