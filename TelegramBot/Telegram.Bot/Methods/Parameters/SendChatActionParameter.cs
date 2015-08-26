using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Methods.Parameters
{
    public class SendChatActionParameter
    { 
        public SendChatActionParameter(int chatId, string action)
        {
            ChatId = chatId;
            Action = action;
        }

        [JsonProperty(propertyName: "chat_id")]
        public int ChatId { get; set; }

        [JsonProperty(propertyName: "action")]
        public string Action { get; set; }
    }

    public class SendChatActionType
    {
        public const string Typing = "typing";
        public const string UploadPhoto = "upload_photo";
        public const string RecordVideo = "record_video";
        public const string RecordAudio = " record_audio";
        public const string UploadAudio = " record_audio";
        public const string UploadVideo = "upload_video";
        public const string FindLocation = "find_location";
        public const string UploadDocument = "upload_document";
    }
}
