using System;

namespace Otp
{
    public class ConsoleLog : ILog
    {
        public void Save( string message )
        {
            Console.WriteLine( message );
        }
    }
}
