using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Model
{
    public class Update
    {
        [JsonProperty("update_id")]
        public int UpdateId { get; set; }

        public Message Message { get; set; }
    }
}
