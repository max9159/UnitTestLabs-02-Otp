using NUnit.Framework;
using Otp;

namespace OtpUnitTest
{
    public class AuthenticationServiceTests
    {
        private string _account;
        private AuthenticationService _authenticationService;
        private string _password;
        private ProfileForTest _profileForTest;
        private TokenForTest _tokenForTest;

        [SetUp]
        public void Setup()
        {
            _profileForTest = new ProfileForTest();
            _tokenForTest = new TokenForTest();
            _authenticationService = new AuthenticationService( _profileForTest , _tokenForTest );
        }

        [Test]
        public void IsValidTest_Password_Is_Valid()
        {
            GivenAccountAndPassword( "ouch" , "197800000" );

            ShouldReturn( true );
        }

        [Test]
        public void IsValidTest_Password_Is_Invalid()
        {
            GivenAccountAndPassword( "ouch" , "1978" );

            ShouldReturn( false );
        }

        private void ShouldReturn( bool isValid )
        {
            Assert.AreEqual( isValid , _authenticationService.IsValid( _account , _password ) );
        }

        private void GivenAccountAndPassword( string account , string password )
        {
            _account = account;
            _password = password;
        }

    }

    public class TokenForTest : IToken
    {
        public string GetRandom( string account )
        {
            return "00000";
        }
    }

    public class ProfileForTest : IProfile
    {
        public string GetPassword( string account )
        {
            if( account == "ouch" )
            {
                return "1978";
            }

            return string.Empty;
        }
    }
}