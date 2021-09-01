using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBotLog
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = File.ReadAllText("token.txt");
            TelegramBotClient bot = new TelegramBotClient(token);
            UsersHistory history = new UsersHistory();
            bot.OnMessage += (s, a) =>
            {
                var msg = a.Message;
                Console.WriteLine($"{msg.Chat.FirstName}: {msg.Text}");

                history.AddMessage(msg.Chat.Id, msg.Text);
                if (msg.Text == "/id")
                {
                    bot.SendTextMessageAsync(msg.Chat.Id, history.GetID(msg.Chat.Id));
                }
                else if (msg.Text == "/log")
                {
                    bot.SendTextMessageAsync(msg.Chat.Id, history.GetLog(msg.Chat.Id));
                }
            };


            bot.StartReceiving();
            Console.ReadKey();
        }
    }
}
