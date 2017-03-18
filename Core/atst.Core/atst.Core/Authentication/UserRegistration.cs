using System;

namespace atst.Core.Authentication
{
    public class UserRegistration : IUserRegistration
    {
        public bool RegisterUser(string email, string password)
        {
            return true;
        }

        public bool IsUserValid(string email)
        {
            return true;
        }

        public bool AuthenticateUser(string email, string password)
        {
            return true;
        }
    }
}
