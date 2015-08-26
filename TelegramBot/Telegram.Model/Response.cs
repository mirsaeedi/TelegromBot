using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Telegram.Model
{
    public class Response<T>
    {
        public bool Ok { get; set; }

        public T Result { get; set; }
    }
}
