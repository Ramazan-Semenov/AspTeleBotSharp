using AspTeleBotSharp.Models.DataContext;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AspTeleBotSharp.Models.ViewModel
{
    internal class ViewModelMainWindow : BaseViewModel
    {

        public ViewModelMainWindow()
        {
            //    ObservableCollection<Questions> q = new ObservableCollection<Questions>(Models.DataContext.ContextQuest.GetQuestions());
            //    Models.ReadWriteJson.ReadWriteF.SaveQuestions(@"C:\Users\Roma\Desktop\WPFBOTEKS\bin\Debug\QuestionsFile\QuestionsFile.quest", q);

        }
        public ObservableCollection<BotUser> UsList { get => UserContext.Users; set { UserContext.Users = value; OnPropertyChanged(nameof(UsList)); Debug.WriteLine("sddddddddddd"); } }

        //  public ObservableCollection<UserEmail> UsList { get=> UserContext.UserEmails; set { UserContext.UserEmails = value; OnPropertyChanged(nameof(UsList)); } }

    }
}