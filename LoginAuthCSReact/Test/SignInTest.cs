using NUnit.Framework;
using LoginAuthCSReact;
using LoginAuthCSReact.Model;
using LoginAuthCSReact.DataAccessLayer;
using Microsoft.Extensions.Configuration;

namespace Test
{
    class SignInTest
    {
        [TestFixture]
        public class AuthDLTests
        {
            private AuthDL _authDL;

            [SetUp]
            public void SetUp()
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                _authDL = new AuthDL(config);
            }

            [Test]
            public async Task SignIn_ShouldReturnSuccessMessage_WhenCredentialsAreValid()
            {
                // Arrange
                var request = new SignInRequest
                {
                    UserName = "dummyuser",
                    Password = "password",
                    Role = "User"
                };

                // Act
                var result = await _authDL.SignIn(request);

                // Assert
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Message, Is.EqualTo("Login Successfully"));
            }

            [Test]
            public async Task SignIn_ShouldReturnUnsuccessMessage_WhenCredentialsAreInvalid()
            {
                // Arrange
                var request = new SignInRequest
                {
                    UserName = "invaliduser",
                    Password = "invalidpassword",
                    Role = "User"
                };

                // Act
                var result = await _authDL.SignIn(request);

                // Assert
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Message, Is.EqualTo("Login Unsuccessfully"));
            }

            [Test]
            public async Task SignUp_ShouldReturnSuccessMessage_WhenSignUpIsSuccessful()
            {
                // Arrange
                var request = new SignUpRequest
                {
                    UserName = "newuser",
                    Password = "newpassword",
                    ConfigPassword = "newpassword",
                    Role = "User"
                };

                // Act
                var result = await _authDL.SignUp(request);

                // Assert
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Message, Is.EqualTo("Successful"));
            }
        }
    }
}