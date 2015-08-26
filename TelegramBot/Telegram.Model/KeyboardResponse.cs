using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Model
{
    public abstract class ReplyMarkup
    {
        public bool Selective { get; set; }
    }
}
