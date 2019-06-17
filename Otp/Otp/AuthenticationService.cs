namespace Otp
{
    public class AuthenticationService
    {
        private IProfile _profileDao;
        private IToken _rsaTokenDao;
        private ILog _logger;

        public AuthenticationService()
        {
            _profileDao = new ProfileDao();
            _rsaTokenDao = new RsaTokenDao();
            _logger = new ConsoleLog();
        }

        public AuthenticationService( IProfile profileDao , IToken rsaTokenDao , ILog logger )
        {
            _profileDao = profileDao;
            _rsaTokenDao = rsaTokenDao;
            _logger = logger;
        }

        public bool IsValid( string account , string password )
        {
            // 根據 account 取得自訂密碼
            var passwordFromDao = _profileDao.GetPassword( account );

            // 根據 account 取得 RSA token 目前的亂數
            var randomCode = _rsaTokenDao.GetRandom( account );

            // 驗證傳入的 password 是否等於自訂密碼 + RSA token亂數
            var validPassword = passwordFromDao + randomCode;

            bool isValid = password == validPassword;

            if( isValid == false )
            {
                _logger.Save( $"Account:{account} tried to login failed." );
            }

            return isValid;
        }
    }
}
