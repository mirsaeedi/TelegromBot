using TelegramBot.Telegram.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Methods.Parameters
{
    public class SendLocationParameter<T> : ReplyMarkupParameter<T>
        where T : ReplyMarkup
    {
        public SendLocationParameter(int chatId, double latitude,double longitude)
        {
            ChatId = chatId;
            Latitude = latitude;
            Longitude = longitude;
        }

        [JsonProperty(propertyName: "chat_id")]
        public int ChatId { get; set; }

        [JsonProperty(propertyName: "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(propertyName: "longitude")]
        public double Longitude { get; set; }
    }
}
