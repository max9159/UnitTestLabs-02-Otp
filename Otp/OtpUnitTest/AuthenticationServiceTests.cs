using NUnit.Framework;
using Otp;

namespace OtpUnitTest
{
    public class AuthenticationServiceTests
    {
        private AuthenticationService _authenticationService;


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsValidTest_Password_Is_Valid()
        {
            //Arrange
            _authenticationService = new AuthenticationService( new ProfileForTest() , new TokenForTest() );

            //Action
            var actual = _authenticationService.IsValid( "ouch" , "197800000" );

            //Assert
            Assert.AreEqual( true , actual );
        }

        [Test]
        public void IsValidTest_Password_Is_Invalid()
        {
            //Arrange
            _authenticationService = new AuthenticationService( new ProfileForTest() , new TokenForTest() );

            //Action
            var actual = _authenticationService.IsValid( "ouch" , "1234" );

            //Assert
            Assert.AreEqual( false , actual );
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