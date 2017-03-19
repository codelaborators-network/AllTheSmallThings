using System;
using atst.Core.Integration;
using atst.Core.Tracking;
using ApiRole.Modules.Tracking;
using ApiRole.Modules.Tracking.Models;
using Moq;
using Nancy;
using Nancy.Testing;
using Should;
using Xunit;

namespace ApiRole.Tests.Modules.Tracking
{
    public class TrackingModuleFixture
    {
        private readonly Mock<IXpTracking> _xpTracking;

        private readonly Browser _browser;
        public TrackingModuleFixture()
        {
            _xpTracking = new Mock<IXpTracking>();
            var module = new TrackingModule(_xpTracking.Object);
            _browser = BrowserBuilder.CreateNullBrowserForLogicTests(module);
        }

        [Fact]
        public void ApplXp_Success()
        {
            //Arrange
            var user = new XpModel { UserName = "me@test.com", Xp = 123456, IntegrationsProvider = IntegrationsProviderTypes.GitHub };
           // _xpTracking.Setup(x => x.ApplyTracking(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<>())).Returns(true);

            //Act
            var response = _browser.Put("/api/tracking/", x => x.JsonBody(user));

            //Assert
            response.StatusCode.ShouldEqual(HttpStatusCode.OK);
           // _xpTracking.Verify(x => x.ApplyTracking(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void ApplXp_FailInvalidUser()
        {
            //Arrange
            var user = new XpModel { UserName = string.Empty, Xp = 123456, IntegrationsProvider = IntegrationsProviderTypes.GitHub };

            //Act
            var response = _browser.Put("/api/tracking/", x => x.JsonBody(user));

            //Assert
            response.StatusCode.ShouldEqual(HttpStatusCode.BadRequest);
           // _xpTracking.Verify(x => x.ApplyTracking(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void ApplXp_FailApplyFailure()
        {
            //Arrange
            var user = new XpModel { UserName = "me@test.com", Xp = 123456, IntegrationsProvider = IntegrationsProviderTypes.GitHub };
           // _xpTracking.Setup(x => x.ApplyTracking(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            //Act
            var response = _browser.Put("/api/tracking/", x => x.JsonBody(user));

            //Assert
            response.StatusCode.ShouldEqual(HttpStatusCode.BadRequest);
           // _xpTracking.Verify(x => x.ApplyTracking(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}