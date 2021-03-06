using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AspTeleBotSharp.Models
{
    public class BotUser : INotifyPropertyChanged, IEquatable<BotUser>
    {

        public BotUser(string NikeName, long ChatId, ObservableCollection<Questions> questions)
        {
            id = ChatId;
            nike = NikeName;
            this.questions = questions;
            Messages = new ObservableCollection<string>();
        }
        public BotUser(string NikeName, long ChatId)
        {
            id = ChatId;
            nike = NikeName;
            Messages = new ObservableCollection<string>();
        }
        public ObservableCollection<Questions> questions { get; set; }

        public BotUser()
        {
        }

        private int count = 0;

        public int Сount
        {
            get => count;
            set => count = value;
        }
        private long id;

        public long ID
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
            }


        }

        private string nike;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Nike
        {
            get => nike;
            set
            {
                nike = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nike)));

            }
        }

        public bool Equals(BotUser other)
        {
            return other.ID == id;
        }

        public ObservableCollection<string> Messages { get; set; }

        public void AddMessage(string Text)
        {
            Messages.Add(Text);
        }

        //public static explicit operator BotUser(UserEmail v)
        //{


        //    return new BotUser(); ;

        //}
    }
}