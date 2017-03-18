using atst.Core.Integration;
using ApiRole.Modules.Integrations;
using Moq;
using Nancy;
using Nancy.Testing;
using Should;
using Xunit;

namespace ApiRole.Tests.Modules.Integrations
{
    public class IntegrationsModuleFixture
    {
        private readonly Mock<IIntegrationProviders> _integrationProviders;

        private readonly Browser _browser;
        public IntegrationsModuleFixture()
        {
            _integrationProviders = new Mock<IIntegrationProviders>();
            var module = new IntegrationsModule(_integrationProviders.Object);
            _browser = BrowserBuilder.CreateNullBrowserForLogicTests(module);
        }

        [Fact]
        public void GetProviderTypes()
        {
            ////Arrange
            //var payLoad = new[]
            //{
            //    "GitHub",
            //    "Email",
            //    "Telephone",
            //    "SourceSafe",
            //    "SVN",
            //    "VSTS",
            //    "TFS-Onsite"
            //};

            //_integrationProviders.Setup(x => x.GetProviderTypes()).Returns(payLoad);

            ////Act
            //var response = _browser.Get("/api/integration/providers/");

            ////Assert
            //response.StatusCode.ShouldEqual(HttpStatusCode.OK);
            //_integrationProviders.Verify(x => x.GetProviderTypes(),Times.Once);
        }
    }
}
