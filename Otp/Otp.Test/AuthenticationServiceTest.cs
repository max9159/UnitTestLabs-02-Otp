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

            var log = Substitute.For<IConsoleLog>();

            var target = new AuthenticationService(profile, token, log);

            const string account = "Max";
            const string password = "tryError";

            //act
            var actual = target.IsValid(account, password);
            log.Received(1).Save("account:Max tried to login failed.");
            log.Received(1).Save(Arg.Is<string>(x => x.Contains("failed")));

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

            var log = Substitute.For<IConsoleLog>();
            log.Received(0).Save(null);
            log.DidNotReceive().Save(null);

            var target = new AuthenticationService(profile, token, log);
            const string account = "Max";
            const string password = "9159random";

            //act
            var actual = target.IsValid(account, password);

            // assert
            Assert.IsTrue(actual);
        }
    }
}
