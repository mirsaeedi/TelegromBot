using TelegramBot.Telegram.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Telegram.Methods.Parameters;
using System.Net.Http.Headers;
using TelegramBot.Telegram.Bot.Methods;
using TelegramBot.Telegram.Bot.Methods.Parameters;

namespace TelegramBot.Telegram.Bot
{
    public class BotBase : IBot
    {
        protected JsonSerializerSettings JsonSerializerSettings { get; private set; }
        protected string Token { get; private set; }
        protected HttpClient HttpClient { get; private set; }
        public BotBase(string token)
        {
            Token = token;
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://api.telegram.org/bot"+ Token + "/");
            JsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public User GetMe()
        {
            var method = new GetMe();
            var result = method.Execute(new GetMeParameter(), HttpClient);
            return result.Result;
        }

        public Update[] GetUpdates(GetUpdatesParameter parameter)
        {
            var method = new GetUpdate();
            return method.Execute(parameter, HttpClient).Result;
        }

        public bool SendChatAction(SendChatActionParameter parameter)
        {
            var method = new SendChatAction();
            return method.Execute(parameter, HttpClient).Result;
        }

        public Message SendMessage<R, P>(P parameter)
            where R : ReplyMarkup
            where P : SendMessageParameter<R>
        {
            var method = new SendMessage<R,P>();
            return method.Execute(parameter, HttpClient).Result;
        }

        public Message SendDocument<R, P>(P parameter)
            where R : ReplyMarkup
            where P : SendDocumentParameter<R>
        {
            var method = new SendDocument<R,P>();
            return method.Execute(parameter, HttpClient).Result;
        }

        public Message SendPhoto<R, P>(P parameter)
            where R : ReplyMarkup
            where P : SendPhotoParameter<R>
        {
            var method = new SendPhoto<R,P>();
            return method.Execute(parameter, HttpClient).Result;
        }

        public Message SendLocation<R, P>(P parameter)
            where R : ReplyMarkup
            where P : SendLocationParameter<R>
        {
            var method = new SendLocation<R, P>();
            return method.Execute(parameter, HttpClient).Result;
        }
    }
}
