using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Model
{
    public class ReplyKeyboardMarkup: ReplyMarkup
    {
        public string[,] Keyboard { get; set; }

        [JsonProperty("resize_keyboard")]
        public bool ResizeKeyboard { get; set; }

        [JsonProperty("one_time_keyboard")]
        public bool OneTimeKeyboard { get; set; }
    }
}
