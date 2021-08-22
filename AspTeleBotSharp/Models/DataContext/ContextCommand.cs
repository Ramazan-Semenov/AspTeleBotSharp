using AspTeleBotSharp.Models.Commandbot;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace AspTeleBotSharp.Models.DataContext
{
    internal class ContextCommand
    {
        private static readonly ObservableCollection<Questions> resert = ContextQuest.Questions;

        private static ObservableCollection<ComBot> com = new ObservableCollection<ComBot>();

        public static ObservableCollection<ComBot> Com { get => com; set => com = value; }

        private static void print()
        {
            TeleBot.Bot.SendTextMessageAsync(1643805757, "Roma");
        }
        public static Dictionary<string, ObservableCollection<Questions>> GetComBots()
        {
            Dictionary<string, ObservableCollection<Questions>> countries = new Dictionary<string, ObservableCollection<Questions>>();

            Models.Entity.u1416851_DataBase1Entities DataBase1Entities = new Entity.u1416851_DataBase1Entities();
           
            
            foreach (var item in DataBase1Entities.InlineKeyboard)
            {
                countries.Add(item.CallBackData,new ObservableCollection<Questions>((IEnumerable<Questions>)DataBase1Entities.Questions.Where(x => x.box == item.box).ToList())) ;
            }
            //ObservableCollection<Questions> questions = new ObservableCollection<Questions>
            //{
            //    new Questions { ID = 1, Text = "фио" },
            //    new Questions { ID = 2, Text = "номер телефона" },
            //    new Questions { ID = 2, Text = "Направление" },
            //    new Questions { ID = 2, Text = "Отправить анкету"/*, replyMarkup = new BotButtons().send() */}
            //};

            //Dictionary<string, ObservableCollection<Questions>> countries = new Dictionary<string, ObservableCollection<Questions>>();
            //countries.Clear();
            //countries.Add("df", questions);


            //List<string> vs = new List<string>();
            //vs.Add("send");

            //ObservableCollection<Questions>  questions  = new ObservableCollection<Questions>();

            //questions.Add(new Questions { ID = 1, Text = "фио" });
            //questions.Add(new Questions { ID = 2, Text = "номер телефона" });
            //questions.Add(new Questions { ID = 2, Text = "Направление" });
            //questions.Add(new Questions { ID = 2, Text = "Отправить анкету"/*, replyMarkup = new BotButtons().send() */}) ;

            //ObservableCollection<Questions> command1 = new ObservableCollection<Questions>();
            //command1.Add(new Questions { ID = 2, Text = "Отправлено" });
            //ObservableCollection<Questions> questions1 = new ObservableCollection<Questions>();
            //questions1.Add(new Questions { ID = 1, Text = @" Центральная приемная комиссия \n350072,
            //    г.Краснодар, \nул.Московская,
            //    д. 2 «А»,
            //    ауд. 111,
            //    112 \nТел.: (861) 255 - 25 - 32,
            //    (861) 274 - 65 - 71" });
            ////////////////////////////////////////////////////////////////////
            //com.Add(new ComBot(questions, write: true) { Name = "подача документов" });
            //com.Add(new ComBot( write: false) { Name = "правила" });
            //com.Add(new ComBot( write: false) { Name = "перечень испытаний" });
            //com.Add(new ComBot(questions1, write: false) { Name = "информация" });
            //com.Add(new ComBot(resert, write: false) { Name = "Начать с начала" });
            //com.Add(new ComBot( write: false) { Name = "стоимость обучения" });
            //com.Add(new ComBot( write: false) { Name = "Другое" });


            //  com.Add(new ComBot(questions,print)  { Name = "send" });

            return countries;

        }
        public static void AddComBots(ComBot comBot)
        {

            com.Add(comBot);
        }
        public static void DelComBots(ComBot comBot)
        {

            com.Remove(comBot);

        }
    }
}