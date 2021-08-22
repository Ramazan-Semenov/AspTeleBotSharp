using AspTeleBotSharp.Models.Commandbot;
using AspTeleBotSharp.Models.DataContext;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace AspTeleBotSharp.Models.BotStart
{
    public class StartBot
    {
        private static readonly bool ff = true;
      //  private readonly ObservableCollection<ComBot> com = new ObservableCollection<ComBot>();

        public static ObservableCollection<Questions> questions = ContextQuest.Questions;

    //    private static readonly ObservableCollection<Questions> command_1;





        //public StartBot()
        //{

        //    Models.DataContext.ContextQuest.GetQuestions();
        //}
        public StartBot()
        {


            Debug.WriteLine("ffffffffffffffffffffffffffffffffff");

        }

        public async Task start()
        {
            ContextQuest.GetQuestions();
           TeleBot.Bot.OnMessage += OnMessageHandler;
            TeleBot.Bot.OnCallbackQuery += OnInlineQueryHandler;

            TeleBot.Bot.StartReceiving();

            Debug.WriteLine("Бот запущен");


        }
        public async Task stop()
        {
            UserContext.Users.Clear();
            ContextQuest.GetQuestions().Clear();
            TeleBot.Bot.OnMessage -=  OnMessageHandler;
            TeleBot.Bot.OnCallbackQuery -= OnInlineQueryHandler;

            TeleBot.Bot.StopReceiving();

        }

        private async void OnInlineQueryHandler(object sender, CallbackQueryEventArgs e)
        {

            BotUser person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id, questions);

            Dictionary<string, ObservableCollection<Questions>> com = ContextCommand.GetComBots();


            com.Add("Кнопка", questions);
            foreach (KeyValuePair<string, ObservableCollection<Questions>> item in com)
            {
                if (e.CallbackQuery.Data == item.Key)
                {
                    //ff = item.ff;
                    //item.ex(e);
                    UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
                    UserContext.Users[UserContext.Users.IndexOf(person)].questions = item.Value;
                    new MessageClient(UserContext.Users, questions, read: ff, UserContext.UserEmails).GenMessage(e);

                    break;
                }
                //_bot.DeleteMessageAsync(e.CallbackQuery.Message.Chat.Id, e.Message.MessageId);
            }

            //////            if (e.CallbackQuery.Data == "подача документов")
            //////            {
            //////                ff = true;
            //////                command_1 = new ObservableCollection<Questions>();


            //////                command_1.Add(new Questions { ID = 1, Text = "фио" });
            //////                command_1.Add(new Questions { ID = 2, Text = "Номер телефона" });
            //////                command_1.Add(new Questions { ID = 3, Text = "На какое направление хотите поступить? \nИКСИиБ\nИНГЭ\nИПиПП\nИЭУБ\nИСТИ\nИФН" });
            //////                command_1.Add(new Questions { ID = 3, Text = "Копия паспорта" });
            //////                command_1.Add(new Questions { ID = 3, Text = "Копия аттестата" });
            //////                command_1.Add(new Questions { ID = 3, Text = "Год рождения\n (ДД.MM.ГГГГ)" });


            //////                command_1.Add(new Questions { ID = 2, Text = "Конец"/*, replyMarkup = new BotButtons().send()*/ });

            //////                //questions = command_1;
            //////                //   var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id, questions);
            //////                UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
            //////                UserContext. Users[UserContext.Users.IndexOf(person)].questions = command_1;
            //////                new MessageClient(UserContext.Users, questions, read: ff, UserContext.UserEmails).GenMessage(e);


            //////            }
            //////            if (e.CallbackQuery.Data == "интитутах")
            //////            {
            //////                ff = true;
            //////                command_1 = new ObservableCollection<Questions>();



            //////                command_1.Add(new Questions { ID = 3, Text = "Выберите институт"/*, replyMarkup = new BotButtons().InlineInfo()*/ });
            //////                //questions = command_1;
            //////                //   var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id, questions);
            //////                UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
            //////                UserContext.Users[UserContext.Users.IndexOf(person)].questions = command_1;
            //////                new MessageClient(UserContext.Users, questions, read: ff, UserContext.UserEmails).GenMessage(e);


            //////            }
            //////            if (e.CallbackQuery.Data == "ИКСИБ")
            //////            {
            //////                ff = true;
            //////                command_1 = new ObservableCollection<Questions>();



            //////                command_1.Add(new Questions { ID = 3, Text = @"УГС НП КТ: 350000, г. Краснодар, ул. Красная, д. 135, ауд. 91.
            //////Телефон: (861) 259 - 60 - 83
            //////Эл.почта: iksib@mail.ru

            //////УГС НП ИБ: 350000,
            //////                    г.Краснодар,
            //////                    ул.Красная,
            //////                    д. 91,
            //////                    ауд. 204.
            //////Телефон: (861) 253 - 47 - 31
            //////Эл.почта: ktibmail@kubstu.ru" });
            //////                //questions = command_1;
            //////                //   var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id, questions);
            //////                UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
            //////                UserContext.Users[UserContext.Users.IndexOf(person)].questions = command_1;
            //////                new MessageClient(UserContext.Users, questions, read: ff, UserContext.UserEmails).GenMessage(e);


            //////            }
            //////            if (e.CallbackQuery.Data == "информация")
            //////            {
            //////                using (var stream = System.IO.File.OpenRead(@"C:\Users\Roma\Desktop\WPFBOTEKS\Image\О наличии общежитий.png"))
            //////                {

            //////                    await TeleBot.Bot.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, photo: new InputOnlineFile(stream));
            //////                    UserContext.Users[UserContext.Users.IndexOf(person)].questions = questions;

            //////                }
            //////            }
            //////            if (e.CallbackQuery.Data== "Начать с начала")
            //////            {

            //////                UserContext.Users[UserContext.Users.IndexOf(person)].questions = questions;
            //////                UserContext.Users[UserContext.Users.IndexOf(person)].Сount=0;
            //////                new MessageClient(UserContext.Users, questions, read: ff, UserContext.UserEmails).GenMessage(e);
            //////            }
            //////            if (e.CallbackQuery.Data == "перечень испытаний")
            //////            {
            //////                using (var stream = System.IO.File.OpenRead(@"C:\Users\Roma\Desktop\WPFBOTEKS\Image\Перечни вступительных испытаний маг.png"))
            //////                {

            //////                    await TeleBot.Bot.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, photo: new InputOnlineFile(stream));
            //////                    UserContext.Users[UserContext.Users.IndexOf(person)].questions = questions;


            //////                }
            //////                using (var stream = System.IO.File.OpenRead(@"C:\Users\Roma\Desktop\WPFBOTEKS\Image\Перечни вступительных испытаний бак и спец.png"))
            //////                {

            //////                    await TeleBot.Bot.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, photo: new InputOnlineFile(stream));
            //////                    UserContext.Users[UserContext.Users.IndexOf(person)].questions = questions;


            //////                }
            //////            }
            //////            if (e.CallbackQuery.Data == "правила")
            //////            {
            //////                await TeleBot.Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Command_2");
            //////            }
            //////            if (e.CallbackQuery.Data == "стоимость обучения")
            //////            {
            //////                //InputOnlineFile file = new InputOnlineFile();

            //////                using(var stream = System.IO.File.OpenRead(@"C:\Users\Roma\Desktop\WPFBOTEKS\Image\Оплата.jpg"))
            //////                {

            //////                    await TeleBot.Bot.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, photo: new InputOnlineFile(stream));

            //////                }

            //////            }
            //////            if (e.CallbackQuery.Data == "Другое")
            //////            {
            //////                await TeleBot.Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Command_2");
            //////            }
            //////            if (e.CallbackQuery.Data == "send")
            //////            {

            //////                string text = "";
            //////                await TeleBot.Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Отправлено");
            //////                foreach (var item in UserContext.UserEmails)
            //////                {
            //////                    foreach (var item1 in item.Messages)
            //////                    {
            //////                        text += "\n" + item1;
            //////                        Debug.WriteLine(item1);

            //////                    }
            //////                }
            //////                   await new Save().sAsync(new Save().creatdir(@"C:\Users\Roma\Desktop\проверка", e.CallbackQuery.Message.Chat.Id.ToString()) + "\\" + e.CallbackQuery.Message.Chat.Id.ToString() + ".txt", text);
            //////            }

            //}
            //else if (e.CallbackQuery.Data == "Command_3")
            //{
            //    questions = new ObservableCollection<Questions>();
            //    questions = resert;
            //    new MessageClient(UserContext.Users, questions).GenMessage(e);


            //    //   await bot.Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Command_2");
            //}


        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {

            //MessageBox.Show(e.Message.Type.ToString());
            if (e.Message.Type == MessageType.Text)
            {

                new MessageClient(UserContext.Users, mes: questions, read: ff, userEmails: UserContext.UserEmails).GenMessage(e);

            }
            else if (e.Message.Type == MessageType.Photo)
            {
                await new MessageClient(UserContext.Users, questions).DownloadPhoto(e);
            }
            else if (e.Message.Type == MessageType.Document)
            {
                await new MessageClient(UserContext.Users, questions).DownloadDocument(e);
            }


        }


    }
}