using TelegramBot.Telegram.Bot.Methods.Base;
using TelegramBot.Telegram.Model;
using TelegramBot.Telegram.Methods.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Bot.Methods
{
    internal class SendDocument<R, P> : MethodBase<P, Message>
        where R : ReplyMarkup
        where P : SendDocumentParameter<R>
    {
        public override HttpVerb HttpVerb
        {
            get
            {
                return HttpVerb.Post;
            }
        }

        public override string MethodName
        {
            get
            {
                return "sendDocument";
            }
        }
    }
}
