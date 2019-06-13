using NSubstitute;
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
            var profileForTest = Substitute.For<IProfile>();
            profileForTest.GetPassword( "ouch" ).Returns( "1978" );

            var tokenForTest = Substitute.For<IToken>();
            tokenForTest.GetRandom( string.Empty ).ReturnsForAnyArgs( "000000" );

            _authenticationService = new AuthenticationService( profileForTest , tokenForTest );

            //Action
            var actual = _authenticationService.IsValid( "ouch" , "1978000000" );

            //Assert
            Assert.AreEqual( true , actual );
        }

        [Test]
        public void IsValidTest_Password_Is_Invalid()
        {
            //Arrange
            var profileForTest = Substitute.For<IProfile>();
            profileForTest.GetPassword( "ouch" ).Returns( "1978" );

            var tokenForTest = Substitute.For<IToken>();
            tokenForTest.GetRandom( string.Empty ).ReturnsForAnyArgs( "000000" );

            _authenticationService = new AuthenticationService( profileForTest , tokenForTest );

            //Action
            var actual = _authenticationService.IsValid( "ouch" , "1234" );

            //Assert
            Assert.AreEqual( false , actual );
        }
    }
}