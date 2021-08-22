using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace AspTeleBotSharp.Models.ReadWriteJson
{
    public class ReadWriteF
    {
        public static void SaveInlineKeyboardButton(string path, ObservableCollection<InlineKeyboardButton> collection)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            using (BinaryWriter binWriter = new BinaryWriter(fs))
            {


                binWriter.Write(collection.Count); //(Int32) записываем кол-во элементов
                foreach (InlineKeyboardButton item in collection)
                {
                    binWriter.Write(item.CallbackData);
                    binWriter.Write(item.Text);

                }

            }
        }

        public static ObservableCollection<InlineKeyboardButton> LoadInlineKeyboardButton(string path)
        {
            ObservableCollection<InlineKeyboardButton> persons = new ObservableCollection<InlineKeyboardButton>();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (BinaryReader binReader = new BinaryReader(fs))
                {
                    int quantity = binReader.ReadInt32();

                    for (int i = 0; i < quantity; i++)
                    {
                        string callbackdata = binReader.ReadString();
                        string text = binReader.ReadString();

                        persons.Add(new InlineKeyboardButton { Text = text, CallbackData = callbackdata });
                    }
                }
                return persons;
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.Message + ":  public static ObservableCollection<InlineKeyboardButton> LoadInlineKeyboardButton(string path)");
                return persons;
            }

        }

        //--------------------------------------------------------------------------------------------------
        public void SaveQuestions(string path, ObservableCollection<Questions> collection)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (BinaryWriter binWriter = new BinaryWriter(fs, Encoding.UTF8))
                {
                    foreach (Questions item in collection)
                    {
                        binWriter.Write(item.Text);  //(UInt32)
                        binWriter.Write(item.replyMarkuppath); //(string)
                    }

                    //binWriter.Write(collection.Count); //(Int32) записываем кол-во элементов
                    //for (int i = 0; i < collection.Count; i++)
                    //{
                    //    binWriter.Write(collection[i].Text);  //(UInt32)
                    //    binWriter.Write(collection[i].replyMarkuppath); //(string)
                    //}

                }
            }
        }

        public ObservableCollection<Questions> LoadQuestions(string path)
        {
            ObservableCollection<Questions> persons = new ObservableCollection<Questions>();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (BinaryReader binReader = new BinaryReader(fs, Encoding.UTF8))
                    {
                        //var f = binReader.ReadInt32();
                        //int quantity = binReader.ReadInt32();

                        while (binReader.PeekChar() > -1)
                        {
                            string text = binReader.ReadString();
                            string ReplyMarkuppath = binReader.ReadString();



                            persons.Add(new Questions
                            {
                                Text = text,

                                replyMarkuppath = ReplyMarkuppath
                            });
                        }
                    }
                }
                return persons;
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.Message + ":  public static ObservableCollection<InlineKeyboardButton> LoadInlineKeyboardButton(string path)");
                return persons;
            }

        }



    }
}