using System.Collections.ObjectModel;

namespace AspTeleBotSharp.Models.DataContext
{
    internal class ContextQuest
    {

        private static ObservableCollection<Questions> questions = GetQuestions();

        public static ObservableCollection<Questions> Questions { get => questions; set => questions = value; }

        public ContextQuest()
        {
            if (questions == null)
            {
                questions = new ObservableCollection<Questions>();
            }
        }

        public static ObservableCollection<Questions> GetQuestions()

        {
            Models.Entity.u1416851_DataBase1Entities entities = new Models.Entity.u1416851_DataBase1Entities();
            ////var x = new Models.ReadWriteJson.ReadWriteF();
            ////ObservableCollection<Questions> ques = new ObservableCollection<Questions>();
            ////ques.Add(new Models.Questions { Text = "sdfasdf", replyMarkuppath = "qreunqir" });

            //foreach (var item in x.LoadQuestions(@"C:\Users\Roma\Desktop\tyty.quest"))
            //{
            //   MessageBox.Show( item.Text);
            //}

            if (questions == null)
            {
                questions = new ObservableCollection<Questions>();
            }
            foreach (Entity.Questions item in entities.Questions)
            {
                questions.Add(new Models.Questions()
                {
                    ID = item.Id,
                    Text = item.Text,
                    replyMarkuppath = item.replyMarkupBox,
                    Image = item.Image,
                    file = item.file,
                    Type = item.Type
                });
            }



            //questions = new Models.ReadWriteJson.ReadWiteJson<ObservableCollection<Questions>>().ReadJsonsin(@"C:\Users\Roma\Desktop\WPFBOTEKS\bin\Debug\QuestionsFile\hhh.json");
            //    x.SaveQuestions(@"C:\Users\Roma\Desktop\tyty.quest", questions);
            return questions;
        }

        public static void addquestions(Questions questionsp)
        {

            questions.Add(questionsp);

        }

        public static void Delquestions(int id)
        {

            questions.RemoveAt(id);

        }

    }
}