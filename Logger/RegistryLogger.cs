using Microsoft.Win32;
using System;

namespace Logger
{
    public class RegistryLogger : Logger
    {
        private readonly string _registrySubkey = @"SOFTWARE\SimpleLogger";

        public override void Log(string message)
        {
            lock (lockObj)
            {
                LoggerMessage.Preparation(LogTarget.Registry);
                try
                {
                    var key = Registry.CurrentUser.CreateSubKey(_registrySubkey);
                    key.SetValue("Log " + DateTime.Now.ToString(), LogEntryBuilder(message));
                    key.Close();
                    LoggerMessage.Confirmation(LogTarget.Registry);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    LoggerMessage.Error(LogTarget.Registry);
                }
            }
        }
    }
}