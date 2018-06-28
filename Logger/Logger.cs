using System;

namespace Logger
{
    public abstract class Logger
    {
        protected readonly object lockObj = new object();
        public abstract void Log(string message);

        protected virtual string LogEntryBuilder(string message)
        {
            return $"{ DateTime.Now.ToString()} {message}";
        }
    }
}
