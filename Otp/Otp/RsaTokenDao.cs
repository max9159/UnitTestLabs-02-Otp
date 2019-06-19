using System;

namespace Otp
{
    public class RsaTokenDao : IRsaTokenDao
    {
        public string GetRandom( string account )
        {
            var seed = new Random( Guid.NewGuid().GetHashCode() );
            var result = seed.Next( 0 , 999999 ).ToString( "000000" );
            Console.WriteLine( "Random Code:{0}" , result );

            return result;
        }
    }
}