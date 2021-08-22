using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace AspTeleBotSharp.Models
{
    public class Questions
    {

        private int id;
        public int ID
        {
            get => id;
            set => id = value;
        }

        private string text;
        public string replyMarkuppath { get; set; } = "";

        public string Text
        {
            get => text;
            set => text = value;
        }


        public ParseMode parseMode { get; set; } = ParseMode.Default;
        public bool disableWebPagePreview { get; set; } = false;
        public bool disableNotification { get; set; } = false;
        public int replyToMessageId { get; set; } = 0;

        public IReplyMarkup replyMarkup
        {
            get
            {
                if (!string.IsNullOrEmpty(replyMarkuppath))
                {
                    List<InlineKeyboardButton> vs = new List<InlineKeyboardButton>();

                    List<Entity.InlineKeyboard> inlines = new Models.Entity.u1416851_DataBase1Entities().InlineKeyboard.Where(x => x.box.Contains(replyMarkuppath)).ToList();
                    foreach (Entity.InlineKeyboard item in inlines)
                    {
                        vs.Add(new InlineKeyboardButton
                        {
                            CallbackData = item.CallBackData,
                            Text = item.Text
                        });
                    }

                    return new BotButtons().InlineKeyboardMarkupMaker(vs);
                }
                else
                {
                    return new ReplyKeyboardRemove();
                }
            }
            set => replyMarkup = value;
        }
        public CancellationToken cancellationToken { get; set; } = default;

        public string Image { get; set; }

        public string Type { get; set; }
        public string file { get; set; }

    }
}