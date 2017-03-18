namespace atst.Core.Authentication
{
    public interface IUserRegistration
    {
        bool RegisterUser(string email, string password);
        bool IsUserValid(string email);
        bool AuthenticateUser(string email, string password);
    }
}