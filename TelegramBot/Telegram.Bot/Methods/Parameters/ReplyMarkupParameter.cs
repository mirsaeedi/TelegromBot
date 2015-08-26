using TelegramBot.Telegram.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Methods.Parameters
{
    public abstract class ReplyMarkupParameter<T> where T : ReplyMarkup
    {
        public ReplyMarkupParameter()
        {
            ReplyMarkup = Activator.CreateInstance(typeof(T)) as T;
        }

        [JsonProperty("reply_markup")]
        public T ReplyMarkup { get; set; }
    }
}
