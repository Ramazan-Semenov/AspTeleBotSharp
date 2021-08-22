using Telegram.Bot.Types.ReplyMarkups;

namespace AspTeleBotSharp.Models
{

    public class InlineKeyboard : InlineKeyboardButton
    {
        private int id;

        public int Id { get => id; set => id = value; }
    }
}