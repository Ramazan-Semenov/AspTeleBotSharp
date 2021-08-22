using AspTeleBotSharp.Models.DataContext;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Telegram.Bot.Args;

namespace AspTeleBotSharp.Models
{
    public class MessageClient : TeleBot
    {

        //private ObservableCollection<BotUser> Users;
        //  private ObservableCollection<Questions> mes;
        public static bool Read;
        private readonly ObservableCollection<UserEmail> userEmails;
        private readonly StepQuestionsClass StepQuestions;
        public MessageClient(ObservableCollection<BotUser> Users, ObservableCollection<Questions> mes, bool read = false, ObservableCollection<UserEmail> userEmails = null)
        {
            UserContext.Users = Users;
            ContextQuest.Questions = mes;
            //    this.mes = mes;
            Read = read;
            this.userEmails = userEmails;
            StepQuestions = new StepQuestionsClass(Users/*, mes*/);
        }

        public void GenMessage(MessageEventArgs e)
        {

            //try
            //{
            string msg = $"{DateTime.Now}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";


            Debug.WriteLine(msg);
            NewUser(e);
            //Application.Current.Dispatcher.Invoke(() =>
            //{


            //});
            //}
            //catch { }
        }
        public async Task DownloadDocument(MessageEventArgs e)
        {
            BotUser person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id, ContextQuest.Questions);

            try
            {
                NewUser(e);

                Task<Telegram.Bot.Types.File> file = Bot.GetFileAsync(e.Message.Document.FileId);
                new Save().creatdir(@"C:\Users\Roma\Desktop\проверка", e.Message.Chat.Id.ToString());

                string fileName = @"C:\Users\Roma\Desktop\проверка\" + e.Message.Chat.Id.ToString() + "\\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
                Debug.WriteLine(file.Result.FilePath);
                using (FileStream saveImageStream = File.Open(fileName, FileMode.Create))
                {
                    await Bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
                }
                //    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Document save");
                await Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;

            }
            catch (Exception exp)
            {
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;

                File.AppendAllText("data.log", $"\n{exp.Message}\n");
            }

        }
        public async Task DownloadPhoto(MessageEventArgs e)
        {
            BotUser person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id, ContextQuest.Questions);

            try
            {

                Task<Telegram.Bot.Types.File> file = bot.GetFileAsync(e.Message.Photo.LastOrDefault().FileId);
                new Save().creatdir(@"C:\Users\Roma\Desktop\проверка", e.Message.Chat.Id.ToString());

                string fileName = @"C:\Users\Roma\Desktop\проверка\" + e.Message.Chat.Id.ToString() + "\\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
                Debug.WriteLine(file.Result.FilePath);
                using (FileStream saveImageStream = File.Open(fileName, FileMode.Create))
                {


                    await bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
                }
                //   await bot.SendTextMessageAsync(e.Message.Chat.Id, "Image save");
                await Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);

                //   await Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);

                UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;

            }

            catch (Exception exp)
            {
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;

                File.AppendAllText("data.log", $"\n{exp.Message}\n");
            }
        }
        private void NewUser(MessageEventArgs e)
        {
            //try
            //{

            BotUser person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id, ContextQuest.Questions);
            if (!UserContext.Users.Contains(person))
            {
                UserContext.Users.Add(person);
            }
            UserContext.Users[UserContext.Users.IndexOf(person)].AddMessage($"{person.Nike}: {e.Message.Text}");
            if (Read == true)
            {

                UserEmail person_email = new UserEmail(e.Message.Chat.FirstName, e.Message.Chat.Id);


                if (!userEmails.Contains(person_email))
                {
                    person.Сount = 0;
                    userEmails.Add(person_email);
                    person_email.Сount = 0;
                }
                userEmails[userEmails.IndexOf(person_email)].AddMessage($"{person.Nike}: {e.Message.Text}");
            }

            //////StepQuestions.StepQuestions(person);
            StepQuestions.StepQuestions(e);
            //}
            //catch (Exception exp)
            //{
            //    File.AppendAllText("data.log", $"\n{exp.Message}\n");

            //}
        }
        /// ///////////////////////////////////////////////////////////////////////

        public async Task DownloadDocument(CallbackQueryEventArgs e)
        {
            BotUser person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id, ContextQuest.Questions);
            try
            {
                NewUser(e);

                Task<Telegram.Bot.Types.File> file = Bot.GetFileAsync(e.CallbackQuery.Message.Document.FileId);
                new Save().creatdir(@"C:\Users\Roma\Desktop\проверка", e.CallbackQuery.Message.Chat.Id.ToString());

                string fileName = @"C:\Users\Roma\Desktop\проверка\" + e.CallbackQuery.Message.Chat.Id.ToString() + "\\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
                Debug.WriteLine(file.Result.FilePath);
                using (FileStream saveImageStream = File.Open(fileName, FileMode.Create))
                {
                    await Bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
                }
                await Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Document save");
                await Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);

                UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;

            }
            catch (Exception exp)
            {
                UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;

                File.AppendAllText("data.log", $"\n{exp.Message}\n");

            }

        }
        public async Task DownloadPhoto(CallbackQueryEventArgs e)
        {
            try
            {
                ////newuser(e)
                BotUser person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id, ContextQuest.Questions);

                Task<Telegram.Bot.Types.File> file = bot.GetFileAsync(e.CallbackQuery.Message.Photo.LastOrDefault().FileId);
                new Save().creatdir(@"C:\Users\Roma\Desktop\проверка", e.CallbackQuery.Message.Chat.Id.ToString());
                string fileName = @"C:\Users\Roma\Desktop\проверка\" + e.CallbackQuery.Message.Chat.Id.ToString() + "\\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
                Debug.WriteLine(file.Result.FilePath);
                using (FileStream saveImageStream = File.Open(fileName, FileMode.Create))
                {


                    await bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
                }
                await bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Image save");
                await Bot.SendTextMessageAsync(UserContext.Users[UserContext.Users.IndexOf(person)].ID, ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text, replyMarkup: ContextQuest.Questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);

                //Users[Users.IndexOf(person)].Сount++;
                if (ContextQuest.Questions.Count == UserContext.Users[UserContext.Users.IndexOf(person)].Сount)
                {

                }
                else
                {
                    UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;

                }
            }
            catch { }
        }
        private void NewUser(CallbackQueryEventArgs e)
        {
            //try
            //{

            BotUser person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id, ContextQuest.Questions);
            if (!UserContext.Users.Contains(person))
            {
                UserContext.Users.Add(person);
            }
            UserContext.Users[UserContext.Users.IndexOf(person)].AddMessage($"{person.Nike}: {e.CallbackQuery.Message.Text}");
            //StepQuestions.StepQuestions(person);
            if (Read == true)
            {
                UserEmail person_email = new UserEmail(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id);

                if (!userEmails.Contains(person_email))
                {

                    userEmails.Add(person_email);
                    UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
                }
                userEmails[userEmails.IndexOf(person_email)].AddMessage($"{person.Nike}: {e.CallbackQuery.Message.Text}");
                //     StepQuestions.StepQuestions();
                // MessageBox.Show("Work!!");
            }
            //  UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0;
            StepQuestions.StepQuestions(person);
            //}
            //catch { }
        }
        public void GenMessage(CallbackQueryEventArgs e)
        {
            string msg = $"{DateTime.Now}: {e.CallbackQuery.Message.Chat.FirstName} {e.CallbackQuery.Message.Chat.Id} {e.CallbackQuery.Message.Text}";

            //File.AppendAllText("data.log", $"{msg}\n");

            Debug.WriteLine(msg);
            NewUser(e);
            //Application.Current.Dispatcher.Invoke(() =>
            //{


            //});
        }


    }
}