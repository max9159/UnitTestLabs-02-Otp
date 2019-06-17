namespace Otp
{
    public class ProfileDao
    {
        public virtual string GetPassword( string account )
        {
            return Context.GetPassword( account );
        }
    }
}