using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atst.Core.Authentication;
using ApiRole.Modules.Authentication.Models;
using Nancy;
using Nancy.ModelBinding;

namespace ApiRole.Modules.Authentication
{
    public class AuthenticationModule : BaseModule
    {
        private readonly IUserRegistration _userRegistration;

        protected AuthenticationModule(IUserRegistration userRegistration) : base("Authentication")
        {
            Post["Register"] = _ => RegisterUser();
            Post[""] = _ => Authenicate();

        }

        private dynamic Authenicate()
        {
            var user = this.Bind<UserModel>();

            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                return HttpStatusCode.BadRequest;

            //var isValid = _userRegistration.IsUserValid();

            _userRegistration.RegisterUser(user.UserName, user.Password);


            return HttpStatusCode.OK;
        }

        private dynamic RegisterUser()
        {
            var user = this.Bind<UserModel>();

            return HttpStatusCode.OK;

        }
    }
}