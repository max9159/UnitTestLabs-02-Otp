// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace Otp.Test
{
    [TestFixture]
    public class AuthenticationServiceTest
    {
        [Test]
        public void invalid_account_password()
        {
            //arrange
            var profile = Substitute.For<IProfile>();
            profile.GetPassword("Max").Returns("9159");

            var token = Substitute.For<IRsaTokenDao>();
            token.GetRandom("Max").Returns("random");

            var target = new AuthenticationService(profile, token);
            const string account = "Max";
            const string password = "tryError";

            //act
            var actual = target.IsValid(account, password);

            // assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void success_account_password()
        {
            //arrange
            var profile = Substitute.For<IProfile>();
            profile.GetPassword("Max").Returns("9159");

            var token = Substitute.For<IRsaTokenDao>();
            token.GetRandom("Max").Returns("random");

            var target = new AuthenticationService(profile, token);
            const string account = "Max";
            const string password = "9159random";

            //act
            var actual = target.IsValid(account, password);

            // assert
            Assert.IsTrue(actual);
        }
    }
}
