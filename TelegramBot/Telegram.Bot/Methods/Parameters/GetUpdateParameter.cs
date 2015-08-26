using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Bot.Methods.Parameters
{
    public class GetUpdatesParameter
    {
        public int? Offset { get; set; }

        public int? Limit { get; set; }

        public int? Timeout { get; set; }
    }
}
