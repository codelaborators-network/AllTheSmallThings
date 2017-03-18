using System.Threading.Tasks;
using atst.Core.Authentication.Entities;
using Firebase.Database;

namespace atst.Core.Helpers
{
    public interface IFirebaseHelper
    {
        Task<string> CreateXPRecordAsync(string userName, EventItem eventItem);
        Task<string> CreateLevelRecordAsync(string userName, EventItem eventItem);
        Task<User> GetUser(string userName);
    }
}