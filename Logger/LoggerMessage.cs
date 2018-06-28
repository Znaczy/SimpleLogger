using System;

namespace Logger
{
    public class LoggerMessage
    {
        public static void Preparation(LogTarget target)
        {
            Console.WriteLine($"Creating log in the {target.ToString().ToLower()}... ");
        }

        public static void Confirmation(LogTarget target)
        {
            Console.WriteLine($"Log in the {target.ToString().ToLower()} was created.");
        }

        public static void Error(LogTarget target)
        {
            Console.WriteLine($"Log in the {target.ToString().ToLower()} failed to create.");
        }
    }
}