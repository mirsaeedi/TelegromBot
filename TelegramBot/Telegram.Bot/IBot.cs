using TelegramBot.Telegram.Model;
using TelegramBot.Telegram.Methods.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Telegram.Bot.Methods.Parameters;

namespace TelegramBot.Telegram.Bot
{
    public interface IBot
    {
        User GetMe();

        Update[] GetUpdates(GetUpdatesParameter parameter);

        Message SendMessage<R,P>(P parameter)
            where P : SendMessageParameter<R>
            where R : ReplyMarkup;

        Message SendDocument<R, P>(P parameter)
            where P : SendDocumentParameter<R>
            where R : ReplyMarkup;

        Message SendPhoto<R, P>(P parameter)
            where P : SendPhotoParameter<R>
            where R : ReplyMarkup;

        Message SendLocation<R, P>(P parameter)
            where P : SendLocationParameter<R>
            where R : ReplyMarkup;

        bool SendChatAction(SendChatActionParameter parameter);
    }
}
