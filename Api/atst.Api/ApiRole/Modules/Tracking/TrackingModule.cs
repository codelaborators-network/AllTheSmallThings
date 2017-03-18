using atst.Core.Tracking;
using ApiRole.Modules.Tracking.Models;
using Nancy;
using Nancy.ModelBinding;

namespace ApiRole.Modules.Tracking
{
    public class TrackingModule : NancyModule
    {
        private static string LastRequest { get; set; }

        private readonly IXpTracking _xpTracking;

        public TrackingModule(IXpTracking xpTracking) : base("/api/tracking/")
        {
            _xpTracking = xpTracking;
            
            Put[""] = _ => ApplyXp();
            Get[""] = _ => GetLastRequest();
        }

        private dynamic GetLastRequest()
        {
            return LastRequest;
        }

        private dynamic ApplyXp()
        {
            var xpModel = this.Bind<XpModel>();

            LastRequest = $"username: {xpModel.UserName} -- xp: {xpModel.Xp}";

            Response response;

            if (string.IsNullOrEmpty(xpModel.UserName))
            {
                response = new Response
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Invalid details provided"
                };
            }
            else
            {

                if (_xpTracking.ApplyTracking(xpModel.UserName, xpModel.Xp))
                {
                    response = new Response
                    {
                        StatusCode = HttpStatusCode.OK
                    };
                }
                else
                {
                    response = new Response
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = $"Unable to update xp for user {xpModel.UserName}"
                    };
                }
            }

            return response;

        }

    }
}