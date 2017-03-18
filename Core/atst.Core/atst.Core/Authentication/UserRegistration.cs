using System;

namespace atst.Core.Authentication
{
    public class UserRegistration : IUserRegistration
    {
        public bool RegisterUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsUserValid(string email)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
