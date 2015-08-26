using TelegramBot.Telegram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    public class CustomeKeyboard: ReplyKeyboardMarkup
    {
        public CustomeKeyboard()
        {
            Keyboard = new string[,]
                {
                    {"cat", "dog"},
                    {"bird", "fish"},
                };
        }
    }
}
