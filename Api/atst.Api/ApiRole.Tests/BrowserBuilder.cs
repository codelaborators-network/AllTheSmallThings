using Nancy;
using Nancy.Testing;

namespace ApiRole.Tests
{
    /// <summary>
    /// Browser builders for nancy module tests
    /// </summary>
    public static class BrowserBuilder
    {
        public static Browser CreateNullBrowserForLogicTests(INancyModule moduleUnderTest)
        {
            return new Browser(with =>
            {
                with.Module(moduleUnderTest);
                with.ViewFactory<TestingViewFactory>();
                with.DisableAutoRegistrations();
            });
        }
    }
}
