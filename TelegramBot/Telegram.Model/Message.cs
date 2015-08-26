using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Model
{
    public class Message
    {
        [JsonProperty(PropertyName ="message_id")]
        public int MessageId { get; set; }

        public User From { get; set; }

        public long Date { get; set; }

        public string Text { get; set; }
    }
}
