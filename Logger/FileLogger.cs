using System;
using System.IO;

namespace Logger
{
    public class FileLogger : Logger
    {
        public override void Log(string message)
        {
            lock (lockObj)
            {
                LoggerMessage.Preparation(LogTarget.File);
                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(FilePath(), true))
                    {
                        streamWriter.WriteLine(LogEntryBuilder(message));
                        streamWriter.Close();
                        LoggerMessage.Confirmation(LogTarget.File);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    LoggerMessage.Error(LogTarget.File);
                }
            }
        }

        private string FilePath()
        {
            string path = $"{Directory.GetCurrentDirectory()}/Logs/";
            Directory.CreateDirectory(path);
            string fileName = "simplelogger.txt";
            return $"{path}{fileName}";
        }
    }
}