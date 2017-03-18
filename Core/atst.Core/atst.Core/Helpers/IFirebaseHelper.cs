using System.Threading.Tasks;
using atst.Core.Authentication.Entities;
using Firebase.Database;

namespace atst.Core.Helpers
{
    public interface IFirebaseHelper
    {
        Task<string> CreateRecordAsync(int integrationId, string userName, EventItem eventItem);
        Task<User> GetUser(string userName);
    }
}