namespace atst.Core.Authentication
{
    public interface IUserRegistration
    {
        bool RegisterUser(string email, string password);
    }
}