using System;
using System.IO;

namespace MyLogClass
{
    public class Log
    {
        #region Init Params

        private static object sync = new object();

        #endregion Init Params

        #region Methods: Write

        public static void Write(string eventString)
        {
            try
            {
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog);//создаём директорию для логов если нужно
                string fileName = Path.Combine(pathToLog, "app.log");
                string fullText = string.Format("[{0:dd.MM.yyyy  HH:mm:ss,fff}]  {1}\r\n", DateTime.Now, eventString);
                lock (sync)
                {
                    File.AppendAllText(fileName, fullText);
                }
            }
            catch
            {
                //перехватываем всё и ничего не делаем
            }
        }

        #endregion Methods: Write
    }
}