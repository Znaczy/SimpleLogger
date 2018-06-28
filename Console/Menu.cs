using System;
using Logger;

namespace SimpleLogger
{
    public static class Menu
    {
        public static void Greeting()
        {
            Console.WriteLine("Hello! This is a Simple Logger application demo. " +
                "It will write anything you type to log.");
            ReadMessage();
        }

        private static void ReadMessage()
        {
            Console.WriteLine("Please write a message you want to log: ");
            ChoosingDestination(Console.ReadLine());
        }

        private static void ChoosingDestination(string message)
        {
            Console.WriteLine(@"Chose where do you want your message to be logged in:
            1. file 
            2. registry
            3. eventlog
            4. all above 
            5. non of the above - quit.
            ");
            var dest = Console.ReadKey(true).KeyChar;
            Loop(dest, message);
        }

        private static void Loop(char answer, string message)
        {
            var validAnswers = "1, 2, 3, 4, 5";
            var IsValidAnswer = validAnswers.Contains(answer);

            while (!IsValidAnswer)
            {
                Console.WriteLine(@"Chose between 1, 2, 3, 4 or 5");
                answer = Console.ReadKey(true).KeyChar;
                IsValidAnswer = validAnswers.Contains(answer);
            }

            if (answer == '5') Farewell();
            else ProcedeWithAnswer(answer, message);
        }

        private static void ProcedeWithAnswer(char answer, string message)
        {
            switch (answer)
            {
                case '1':
                    LoggerHelper.Log(LogTarget.File, message);
                    break;
                case '2':
                    LoggerHelper.Log(LogTarget.Registry, message);
                    break;
                case '3':
                    LoggerHelper.Log(LogTarget.EventLog, message);
                    break;
                case '4':
                    LoggerHelper.Log(LogTarget.File, message);
                    LoggerHelper.Log(LogTarget.Registry, message);
                    LoggerHelper.Log(LogTarget.EventLog, message);
                    break;
            }
            QuitOrRepeat();
        }

        private static void QuitOrRepeat()
        {
            Console.WriteLine("Would you like to log some more? (y/n)");
            var ans = Console.ReadKey(true).KeyChar;
            while(!(ans == 'y' || ans == 'n'))
            {
                Console.WriteLine("Yes or no?");
                ans = Console.ReadKey(true).KeyChar;
            }
            if (ans == 'y') ReadMessage();
            else Farewell();
        }

        private static void Farewell()
        {
            Console.Write("Thank you and have a nice day.");
        }
    }
}