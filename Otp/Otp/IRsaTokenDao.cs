namespace Otp
{
    public interface IRsaTokenDao
    {
        string GetRandom(string account);
    }
}