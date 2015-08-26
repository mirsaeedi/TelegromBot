using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Model
{
    public class ForceReply : ReplyMarkup
    {
        [JsonProperty("force_reply")]
        public bool Force
        {
            get
            {
                return true;
            }
        }
    }

}
