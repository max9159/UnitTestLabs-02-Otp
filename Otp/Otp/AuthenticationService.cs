namespace Otp
{
    public class AuthenticationService
    {
        private IProfile _profile;
        private IRsaTokenDao _token;
        private IConsoleLog _consoleLog;

        public AuthenticationService(IProfile profile, IRsaTokenDao token, IConsoleLog consoleLog)
        {
            _consoleLog = consoleLog;
            _profile = profile;
            _token = token;

        }

        public bool IsValid( string account , string password )
        {
            // 根據 account 取得自訂密碼
            var passwordFromDao = _profile.GetPassword( account );

            // 根據 account 取得 RSA token 目前的亂數
            var randomCode = _token.GetRandom( account );

            // 驗證傳入的 password 是否等於自訂密碼 + RSA token亂數
            var validPassword = passwordFromDao + randomCode;

            var isValid = password == validPassword ? true : false;
            if (!isValid)
            {
                _consoleLog.Save($"account:{account} tried to login failed.");
            }
            return isValid;
        }
    }
}
