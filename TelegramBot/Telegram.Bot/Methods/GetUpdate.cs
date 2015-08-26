using TelegramBot.Telegram.Bot.Methods.Base;
using TelegramBot.Telegram.Bot.Methods.Parameters;
using TelegramBot.Telegram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Bot.Methods
{
    internal class GetUpdate : MethodBase<GetUpdatesParameter, Update[]>
    {
        public override HttpVerb HttpVerb
        {
            get
            {
                return HttpVerb.Get;
            }
        }

        public override string MethodName
        {
            get
            {
                return "getUpdates";
            }
        }
    }
}
