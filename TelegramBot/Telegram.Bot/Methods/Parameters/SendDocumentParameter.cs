using TelegramBot.Telegram.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Methods.Parameters
{
    public class SendDocumentParameter<T> : ReplyMarkupParameter<T>
        where T : ReplyMarkup
    {
        public SendDocumentParameter(int chatId, Stream documentStream, string documentFileName)
        {
           
            DocumentFileName = documentFileName;
            DocumentStream = documentStream;
            ChatId = chatId;
        }

        [JsonProperty(propertyName: "chat_id")]
        public int ChatId { get; set; }

        [JsonProperty(propertyName: "reply_to_message_id")]
        public int? ReplyToMessageId { get; set; }

        [JsonIgnore]
        public Stream DocumentStream { get; private set; }

        [JsonIgnore]
        public string DocumentFileName { get; private set; }
    }
}
