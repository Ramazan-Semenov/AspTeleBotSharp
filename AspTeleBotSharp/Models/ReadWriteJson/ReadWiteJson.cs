
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspTeleBotSharp.Models.ReadWriteJson
{
    internal class ReadWiteJson<T> where T : class
    {
        /// <summary>
        /// Запись и создание json файла
        /// </summary>
        /// <param name="path">Место расположение файла</param>
        /// <param name="collection"> Эленемты для записи</param>
        /// <returns></returns>
        public async Task WriteJson(string path, T collection)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {

                    await JsonSerializer.SerializeAsync<T>(fs, collection);
                    Trace.WriteLine("Data has been saved to file");
                    Trace.WriteLine("sdfsdf");

                }
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp + "  :WriteJson(string path,T collection)");
            }
        }
        /// <summary>
        /// Чтение Json файла
        /// </summary>
        /// <param name="path"> Место расположение файла</param>
        /// <returns></returns>
        public async Task<T> ReadJson(string path)
        {
            T r;

            FileStream resultRead = File.OpenRead(path);

            r = await JsonSerializer.DeserializeAsync<T>(resultRead);

            return r;

        }
        public T ReadJsonsin(string path)
        {
            T r;

            string resultRead = File.ReadAllText(path);

            r = JsonSerializer.Deserialize<T>(resultRead);

            return r;

        }

    }
}