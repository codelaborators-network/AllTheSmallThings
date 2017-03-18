using atst.Core.Authentication;
using ApiRole.Modules.Authentication.Models;
using Nancy;
using Nancy.ModelBinding;

namespace ApiRole.Modules.Authentication
{
    public class AuthenticationModule : NancyModule
    {
        private readonly IUserRegistration _userRegistration;

        public AuthenticationModule(IUserRegistration userRegistration) : base("/api/authentication/")
        {
            _userRegistration = userRegistration;

            Post["Register"] = _ => RegisterUser();
            Post[""] = _ => Authenicate();
        }

        private dynamic RegisterUser()
        {
            var user = this.Bind<UserModel>();

            Response response;

            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                response = new Response { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Invalid details provided" };
            }
            else
            {

                if (!_userRegistration.IsUserValid(user.UserName))
                {
                    response = new Response { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Invalid details provided" };
                }
                else
                {
                    response = _userRegistration.RegisterUser(user.UserName, user.Password) ? 
                          new Response { StatusCode = HttpStatusCode.OK, ReasonPhrase = "User Created" } 
                        : new Response { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Unable to created requested user" };
                }

            }

            return response;
        }

        private dynamic Authenicate()
        {
            var user = this.Bind<UserModel>();

            var response = _userRegistration.AuthenticateUser(user.UserName, user.Password) ? 
                new Response { StatusCode = HttpStatusCode.OK } 
                : new Response { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Invalid details provided" };

            return response;

        }
    }
}