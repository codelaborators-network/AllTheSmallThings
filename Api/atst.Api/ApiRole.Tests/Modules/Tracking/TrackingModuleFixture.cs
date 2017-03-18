using atst.Core.Tracking;
using ApiRole.Modules.Tracking;
using Moq;
using Nancy.Testing;

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
    }
}
