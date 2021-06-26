using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class Program
    {
        private static string token = "1864812884:AAFvW7xTRcITf-heJJTmZvEoYapSHOYLlEw";
        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += onMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
            Console.WriteLine("Hello World!");
        }

        private static async void onMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            /*int Id = 1005374355;*/ 


            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом {msg.Text}");
               /* await client.SendTextMessageAsync(msg.Chat.Id,"Привет как дела?",replyToMessageId: msg.MessageId);
                await client.SendStickerAsync(chatId: msg.Chat.Id,sticker: "https://cdn.tlgrm.ru/stickers/22c/b26/22cb267f-a2ab-41e4-8360-fe35ac048c3b/thumb128.webp");*/
                switch(msg.Text)
                {
                    case "Стикер":
                        await client.SendStickerAsync(chatId: msg.Chat.Id, "https://tech.informator.ua/wp-content/uploads/2019/03/Funny-Stickers-2.jpg",replyToMessageId: msg.MessageId, replyMarkup: GetButtons());
                        break;
                    case "Картинка":
                        await client.SendPhotoAsync(chatId: msg.Chat.Id, "https://sun9-20.userapi.com/c850424/v850424285/1885fd/4BasTBUdyy8.jpg",replyToMessageId: msg.MessageId,replyMarkup: GetButtons());
                        break;
                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Выберите команду", replyMarkup: GetButtons());
                        break;
                }
            }
        }
      

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>()
                {
                    new List<KeyboardButton>{ new KeyboardButton {Text = "Стикер" }, new KeyboardButton { Text = "Картинка" } },
                    new List<KeyboardButton>{ new KeyboardButton {Text = "123" }, new KeyboardButton { Text = "456" } }
                }
            };
        }
        
    }
}
