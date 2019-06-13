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
            _authenticationService = new AuthenticationService();

            //Action
            var actual = _authenticationService.IsValid( "ouch" , "1978" );

            //Assert
            Assert.AreEqual( true , actual );
        }

        [Test]
        public void IsValidTest_Password_Is_Invalid()
        {
            //Arrange
            _authenticationService = new AuthenticationService();

            //Action
            var actual = _authenticationService.IsValid( "ouch" , "1978" );

            //Assert
            Assert.AreEqual( false , actual );
        }

    }
}