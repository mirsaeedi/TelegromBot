using TelegramBot.Telegram.Bot;
using TelegramBot.Telegram.Bot.Methods.Parameters;
using TelegramBot.Telegram.Methods.Parameters;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {

            var bot = new BotBase("128682096:AAE_LP3sW5kM-d2Zd_sjhG9slwq4-xsXdWs");
            bot.GetUpdates(new GetUpdatesParameter());
            bot.SendDocument<CustomeKeyboard, SendDocumentParameter<CustomeKeyboard>>
            (new SendDocumentParameter<CustomeKeyboard>(56751056,File.OpenRead(@"C:\Users\Ehsan\Desktop\Photo1067.jpg"), "Photo1067.jpg")
            {
                
            });

            string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {

            }

            Console.ReadLine();
        }
    }
}
