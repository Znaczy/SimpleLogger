using System;
using System.Diagnostics;

namespace Logger
{
    public class EventLogger : Logger
    {
        public override void Log(string message)
        {
            lock (lockObj)
            {
                try
                {
                    LoggerMessage.Preparation(LogTarget.EventLog);
                    using (EventLog eventLog = new EventLog(""))
                    {
                        eventLog.Source = "SimpleLogger";
                        eventLog.WriteEntry(message);
                        LoggerMessage.Confirmation(LogTarget.EventLog);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Execute create.reg with administrator " +
                        "permision to be able to write logs to EventLog.");
                    LoggerMessage.Error(LogTarget.EventLog);
                }
            }
        }
    }
}
