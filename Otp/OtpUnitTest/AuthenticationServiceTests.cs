using NSubstitute;
using NUnit.Framework;
using Otp;

namespace OtpUnitTest
{
    public class AuthenticationServiceTests
    {
        private AuthenticationService _authenticationService;
        private IProfile _profileForTest;
        private IToken _tokenForTest;

        private string _account;
        private string _password;

        [SetUp]
        public void Setup()
        {
            _profileForTest = Substitute.For<IProfile>();
            _profileForTest.GetPassword( "ouch" ).Returns( "1978" );

            _tokenForTest = Substitute.For<IToken>();
            _tokenForTest.GetRandom( string.Empty ).ReturnsForAnyArgs( "000000" );

            _authenticationService = new AuthenticationService( _profileForTest , _tokenForTest );
        }

        [Test]
        public void IsValidTest_Password_Is_Valid()
        {
            GivenAccountAndPassword( "ouch" , "1978000000" );
            ShouldReturn( true );
        }

        [Test]
        public void IsValidTest_Password_Is_Invalid()
        {
            GivenAccountAndPassword( "ouch" , "1234" );
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
}