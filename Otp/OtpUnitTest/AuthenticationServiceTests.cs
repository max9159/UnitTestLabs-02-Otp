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
        private ILog _logger;

        private string _account;
        private string _password;

        [SetUp]
        public void Setup()
        {
            _profileForTest = Substitute.For<IProfile>();
            _profileForTest.GetPassword( "ouch" ).Returns( "1978" );

            _tokenForTest = Substitute.For<IToken>();
            _tokenForTest.GetRandom( string.Empty ).ReturnsForAnyArgs( "000000" );

            _logger = Substitute.For<ILog>();

            _authenticationService = new AuthenticationService( _profileForTest , _tokenForTest , _logger );
        }

        [Test]
        public void IsValidTest_Password_Is_Valid()
        {
            GivenAccountAndPassword( "ouch" , "1978000000" );
            ShouldReturn( true );
        }

        [Test]
        public void IsValidTest_SaveLog_Should_Not_Be_Called()
        {
            GivenAccountAndPassword( "ouch" , "1978000000" );

            _authenticationService.IsValid( _account , _password );

            _logger.DidNotReceive().Save( string.Empty );
        }

        [Test]
        public void IsValidTest_Password_Is_Invalid()
        {
            GivenAccountAndPassword( "ouch" , "1234" );
            ShouldReturn( false );
        }
        [Test]
        public void IsValidTest_SaveLog_Is_Called()
        {
            GivenAccountAndPassword( "ouch" , "1234" );

            _authenticationService.IsValid( _account , _password );

            _logger.Received().Save( Arg.Is<string>( x => x.Contains( "failed" ) ) );
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