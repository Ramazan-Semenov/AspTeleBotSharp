using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AspTeleBotSharp.Models.BaseUser
{
    internal abstract class BaseUser : INotifyPropertyChanged, IEquatable<BaseUser>

    {
        public BaseUser(string nike, long id)
        {
            this.id = id;
            this.nike = nike;

            Messages = new ObservableCollection<string>();
        }

        protected int count = 0;

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

        protected string nike;

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

        public bool Equals(BaseUser other)
        {
            return other.ID == id;
        }

        public ObservableCollection<string> Messages { get; set; }

        public void AddMessage(string Text)
        {
            Messages.Add(Text);
        }
    }
}