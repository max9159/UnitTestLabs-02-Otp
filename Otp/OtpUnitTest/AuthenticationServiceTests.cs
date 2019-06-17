using NUnit.Framework;
using Otp;

namespace OtpUnitTest
{
    public class AuthenticationServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsValidTest_Is_Valid()
        {
            var authenticationService = new AuthenticationService( new ProfileDaoForTest() , new RsaTokenDaoForTest() );

            var actual = authenticationService.IsValid( "ouch" , "1978000000" );

            Assert.AreEqual( true , actual );
        }

        [Test]
        public void IsValidTest_Is_Not_Valid()
        {
            var authenticationService = new AuthenticationService( new ProfileDaoForTest() , new RsaTokenDaoForTest() );

            var actual = authenticationService.IsValid( "ouch" , string.Empty );

            Assert.AreEqual( false , actual );
        }
    }

    public class ProfileDaoForTest : ProfileDao
    {
        public override string GetPassword( string account )
        {
            return account == "ouch" ? "1978" : string.Empty;
        }
    }

    public class RsaTokenDaoForTest : RsaTokenDao
    {
        public override string GetRandom( string account )
        {
            return "000000";
        }
    }
}