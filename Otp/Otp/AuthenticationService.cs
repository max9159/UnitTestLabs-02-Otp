namespace Otp
{
    public class AuthenticationService
    {
        private ProfileDao _profileDao;
        private RsaTokenDao _tokenDao;

        public AuthenticationService()
        {
            _profileDao = new ProfileDao();
            _tokenDao = new RsaTokenDao();
        }

        public AuthenticationService( ProfileDao profileDao , RsaTokenDao rsaTokenDao )
        {
            _profileDao = profileDao;
            _tokenDao = rsaTokenDao;
        }

        public bool IsValid( string account , string password )
        {
            // 根據 account 取得自訂密碼
            var profileDao = _profileDao;
            var passwordFromDao = profileDao.GetPassword( account );

            // 根據 account 取得 RSA token 目前的亂數
            var rsaToken = _tokenDao;
            var randomCode = rsaToken.GetRandom( account );

            // 驗證傳入的 password 是否等於自訂密碼 + RSA token亂數
            var validPassword = passwordFromDao + randomCode;

            return password == validPassword ? true : false;
        }
    }
}
