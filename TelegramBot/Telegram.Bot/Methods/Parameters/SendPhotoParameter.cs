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
    public class SendPhotoParameter<T> : ReplyMarkupParameter<T>
        where T : ReplyMarkup
    {
        public SendPhotoParameter(int chatId,Stream photoStream,string photoFileName)
        {
            PhotoFileName = photoFileName;
            PhotoStream = photoStream;
            ChatId = chatId;
        }

        [JsonProperty(propertyName: "chat_id")]
        public int ChatId { get; set; }

        public string Caption { get; set; }

        [JsonProperty(propertyName: "reply_to_message_id")]
        public int? ReplyToMessageId { get; set; }

        [JsonIgnore]
        public Stream PhotoStream { get; private set; }

        [JsonIgnore]
        public string PhotoFileName { get; private set; }
    }
}
