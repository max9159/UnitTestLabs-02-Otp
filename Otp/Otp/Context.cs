using System.Collections.Generic;

namespace Otp
{
    public static class Context
    {
        public static Dictionary<string , string> Profiles;

        static Context()
        {
            Profiles = new Dictionary<string , string>
            {
                { "ouch" , "1978" } ,
                { "niqolas" , "abcde" }
            };
        }

        public static string GetPassword( string key )
        {
            return Profiles[ key ];
        }
    }
}