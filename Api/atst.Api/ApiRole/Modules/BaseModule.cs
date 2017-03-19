using Nancy;
using Nancy.Responses;

namespace ApiRole.Modules
{
    public class BaseModule : NancyModule
    {
        public BaseModule() 
        {
            Get["/"] = _ => GetDefault();
        }

        private dynamic GetDefault()
        {
          return Response.AsRedirect(
                "http://www.jamesstuddart.co.uk/Content/Images/Instagram/10735256_401141070038537_2107512645_n.jpg",
                RedirectResponse.RedirectType.Temporary);
        }
    }
}