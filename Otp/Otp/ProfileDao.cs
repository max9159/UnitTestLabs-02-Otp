namespace Otp
{
    public class ProfileDao : IProfile
    {
        public string GetPassword( string account )
        {
            return Context.GetPassword( account );
        }
    }
}