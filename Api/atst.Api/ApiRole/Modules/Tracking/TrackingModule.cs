using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atst.Core.Tracking;
using ApiRole.Modules.Tracking.Models;
using Nancy;
using Nancy.ModelBinding;

namespace ApiRole.Modules.Tracking
{
    public class TrackingModule : NancyModule
    {
        private IXpTracking _xpTracking;

        public TrackingModule(IXpTracking xpTracking) : base("/api/tracking/")
        {
            _xpTracking = xpTracking;

            Put[""] = _ => ApplyXp();
        }

        private dynamic ApplyXp()
        {
            var xpModel = this.Bind<XpModel>();

            Response response;

            if (string.IsNullOrEmpty(xpModel.UserName))
            {
                response = new Response
                {
                    StatusCode = HttpStatusCode.Forbidden,
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