namespace Otp
{
    public interface IToken
    {
        string GetRandom( string account );
    }
}