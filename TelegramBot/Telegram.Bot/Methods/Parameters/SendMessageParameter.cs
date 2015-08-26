using TelegramBot.Telegram.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Methods.Parameters
{
    public class SendMessageParameter<T> : ReplyMarkupParameter<T>
        where T : ReplyMarkup
    {
        public SendMessageParameter(int chatId,string text)
        {
            Text = text;
            ChatId = chatId;

        }

        [JsonProperty(PropertyName = "chat_id")]
        public int ChatId { get; set; }

        public string Text { get; set; }

        [JsonProperty(PropertyName = "disable_web_page_preview")]
        public bool? DisableWebPagePreview { get; set; }

        [JsonProperty(PropertyName = "reply_to_message_id")]
        public int? ReplyToMessageId { get; set; }
    }
}
