using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Model
{
    public class ReplyKeyboardHide : ReplyMarkup
    {
        [JsonProperty("hide_keyboard")]
        public bool HideKeyboard { get { return true; } }
    }
}
