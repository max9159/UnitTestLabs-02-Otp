using System;

namespace Otp
{
    public interface IConsoleLog
    {
        void Save(string message);
    }

    public class ConsoleLog : IConsoleLog
    {
        public void Save(string message)
        {
            Console.WriteLine(message);
        }
    }
}