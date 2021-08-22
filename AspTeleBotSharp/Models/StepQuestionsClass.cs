using AspTeleBotSharp.Models.DataContext;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;

namespace AspTeleBotSharp.Models
{
    internal class StepQuestionsClass : TeleBot
    {
        public StepQuestionsClass(ObservableCollection<BotUser> Users/*, ObservableCollection<Questions> mes*/)
        {
            UserContext.Users = Users;
            // ContextQuest.Questions = mes;
        }
        /// <summary>
        /// переход к следующему сообщению
        /// </summary>
        /// <param name = "person" > Клиент, котором</ param >
        public async Task/*void*/ StepQuestions(BotUser person)
        {


            try
            {
                long iD = UserContext.Users[UserContext.Users.IndexOf(person)].ID;

                string text = UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text;
                await Bot.SendTextMessageAsync(iD, text, replyMarkup: UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);
                if (UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Image != null)
                {
                    using (System.IO.FileStream stream = System.IO.File.OpenRead(@"C:\Users\Roma\source\repos\AspTeleBotSharp\AspTeleBotSharp\Image\" + UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Image))
                    {

                        await Bot.SendPhotoAsync(iD, photo: new InputOnlineFile(stream));


                    }
                }
             

                if (UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].file != null)
                {
                    using (System.IO.FileStream stream = System.IO.File.OpenRead(@"C:\Users\Roma\source\repos\AspTeleBotSharp\AspTeleBotSharp\Files\" + UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].file))
                    {

                        await Bot.SendDocumentAsync(iD, document: new InputOnlineFile(stream));


                    }
                }

                UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;
            }
            catch { UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0; }

        }

      async  Task< bool> step(MessageEventArgs e, BotUser person, long iD)
        {

            bool step = false;
            string type = UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Type.ToLower();
            if (type == "int")
            {
                try
                {
                    Convert.ToInt32(e.Message.Text);
                    step = true;
                }
                catch
                {
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Неправильная запись, тип данных должен быть: "+ type , replyToMessageId: e.Message.MessageId);
                    step = false;
                }
            }
             if (type == "date")
            {
                try
                {
                    step = true;
                    Convert.ToDateTime(e.Message.Text);
                }
                catch
                {
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Неправильная запись, тип данных должен быть: " + type, replyToMessageId: e.Message.MessageId);
                    step = false;

                }
            }
             if (type == "string")
            {
                try
                {
                    step = true;
                    Convert.ToString(e.Message.Text);
                }
                catch
                {

                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Неправильная запись, тип данных должен быть: " + type, replyToMessageId: e.Message.MessageId);
                    step = false;

                }
            }

            //if (UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].file != null)
            //{
            //    using (System.IO.FileStream stream = System.IO.File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].file))
            //    {
            //        step = true;
            //        await Bot.SendDocumentAsync(iD, document: new InputOnlineFile(stream));


            //    }
            //}
            return step;
        }
        public async Task/*void*/ StepQuestions(MessageEventArgs e)
        {


            BotUser person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id, ContextQuest.Questions);
           
            try
            {

                long iD = UserContext.Users[UserContext.Users.IndexOf(person)].ID;

                string text = UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Text;
               // Debug.WriteLine(e.Message.Text.GetType().ToString().ToLower() + "////////////////////////////////////////////////////////");
             
                //if (e.Message.Text.GetType().ToString().ToLower()!= UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Type.ToLower())
                //{
                //    await Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Text, replyToMessageId: e.Message.MessageId);
                //}
             
               

                if (step(e,person,iD).Result==true)
                {
                    await Bot.SendTextMessageAsync(iD, text, replyMarkup: UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].replyMarkup);

                    if (UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].file != null)
                    {
                        using (System.IO.FileStream stream = System.IO.File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].file))
                        {
                            await Bot.SendDocumentAsync(iD, document: new InputOnlineFile(stream));


                        }
                    }
                    if (UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Image != null)
                    {
                        using (System.IO.FileStream stream = System.IO.File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "Image\\" + UserContext.Users[UserContext.Users.IndexOf(person)].questions[UserContext.Users[UserContext.Users.IndexOf(person)].Сount].Image))
                        {

                            await Bot.SendPhotoAsync(iD, photo: new InputOnlineFile(stream));

                        }
                    }
                    UserContext.Users[UserContext.Users.IndexOf(person)].Сount++;
                }
               
            }
            catch { UserContext.Users[UserContext.Users.IndexOf(person)].Сount = 0; }


        }

    }
}