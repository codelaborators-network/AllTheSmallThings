using System.Web.Configuration;
using atst.Core.Authentication;
using ApiRole.Modules.Authentication;
using ApiRole.Modules.Authentication.Models;
using Moq;
using Nancy;
using Nancy.Testing;
using Should;
using Xunit;

namespace ApiRole.Tests.Modules.Authentication
{
    public class AuthenticationModuleFixture
    {
        private Mock<IUserRegistration> _userRegistration;

        private Browser _browser;
        public AuthenticationModuleFixture()
        {
            _userRegistration = new Mock<IUserRegistration>();
            var module = new AuthenticationModule(_userRegistration.Object);
            _browser = BrowserBuilder.CreateNullBrowserForLogicTests(module);
        }
        #region registration
        [Fact]
        public void RegisterUser_Success()
        {
            //Arrange
            var user = new UserModel { UserName = "me@test.com", Password = "P@55w0rd!" };
            _userRegistration.Setup(x => x.RegisterUser(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            _userRegistration.Setup(x => x.IsUserValid(It.IsAny<string>())).Returns(true);
            _userRegistration.Setup(x => x.RegisterUser(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            //Act
            var response = _browser.Post("/api/authentication/Register", x => x.JsonBody(user));

            //Assert
            response.StatusCode.ShouldEqual(HttpStatusCode.OK);
            response.ReasonPhrase.ShouldEqual("User Created");
            _userRegistration.Verify(x => x.RegisterUser(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _userRegistration.Verify(x => x.IsUserValid(It.IsAny<string>()), Times.Once);
            _userRegistration.Verify(x => x.RegisterUser(It.IsAny<string>(), It.IsAny<string>()), Times.Once);

        }

        [Fact]
        public void RegisterUser_Failure_InvalidUser()
        {
            //Arrange
            var user = new UserModel { UserName = "me@test.com", Password = "P@55w0rd!" };
            _userRegistration.Setup(x => x.IsUserValid(It.IsAny<string>())).Returns(false);
            _userRegistration.Setup(x => x.RegisterUser(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            //Act
            var response = _browser.Post("/api/authentication/Register", x => x.JsonBody(user));

            //Assert
            response.StatusCode.ShouldEqual(HttpStatusCode.Forbidden);
            response.ReasonPhrase.ShouldEqual("Invalid details provided");
            _userRegistration.Verify(x => x.IsUserValid(It.IsAny<string>()), Times.Once);
            _userRegistration.Verify(x => x.RegisterUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
        [Fact]
        public void RegisterUser_Failure_CreateFailed()
        {
            //Arrange
            var user = new UserModel { UserName = "me@test.com", Password = "P@55w0rd!" };
            _userRegistration.Setup(x => x.IsUserValid(It.IsAny<string>())).Returns(true);
            _userRegistration.Setup(x => x.RegisterUser(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            //Act
            var response = _browser.Post("/api/authentication/Register", x => x.JsonBody(user));

            //Assert
            response.StatusCode.ShouldEqual(HttpStatusCode.Forbidden);
            response.ReasonPhrase.ShouldEqual("Unable to created requested user");
            _userRegistration.Verify(x => x.IsUserValid(It.IsAny<string>()), Times.Once);
            _userRegistration.Verify(x => x.RegisterUser(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void RegisterUser_Failure_EmptyUserDetails()
        {
            //Arrange
            var user = new UserModel { UserName = string.Empty, Password = string.Empty };
            _userRegistration.Setup(x => x.RegisterUser(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            _userRegistration.Setup(x => x.IsUserValid(It.IsAny<string>())).Returns(true);

            //Act
            var response = _browser.Post("/api/authentication/Register", x => x.JsonBody(user));

            //Assert
            response.StatusCode.ShouldEqual(HttpStatusCode.Forbidden);
            response.ReasonPhrase.ShouldEqual("Invalid details provided");
            _userRegistration.Verify(x => x.RegisterUser(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            _userRegistration.Verify(x => x.IsUserValid(It.IsAny<string>()), Times.Never);
        }
        #endregion registration

        #region Authentication
        [Fact]
        public void AuthentionUser_Success()
        {
            //Arrange
            var user = new UserModel { UserName = "me@test.com", Password = "P@55w0rd!" };
            _userRegistration.Setup(x => x.AuthenticateUser(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            //Act
            var response = _browser.Post("/api/authentication/", x => x.JsonBody(user));

            //Assert
            response.StatusCode.ShouldEqual(HttpStatusCode.OK);
            _userRegistration.Verify(x => x.AuthenticateUser(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
        [Fact]
        public void AuthentionUser_Failure()
        {
            //Arrange
            var user = new UserModel { UserName = "me@test.com", Password = "P@55w0rd!" };
            _userRegistration.Setup(x => x.AuthenticateUser(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            //Act
            var response = _browser.Post("/api/authentication/", x => x.JsonBody(user));

            //Assert
            response.StatusCode.ShouldEqual(HttpStatusCode.Forbidden);
            response.ReasonPhrase.ShouldEqual("Invalid details provided");
            _userRegistration.Verify(x => x.AuthenticateUser(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
        #endregion Authentication

    }
}
