using System.Threading.Tasks;
using atst.Core.Authentication.Entities;
using Firebase.Database;

namespace atst.Core.Helpers
{
    public interface IFirebaseHelper
    {
        Task<string> CreateXPRecordAsync(string userName, EventItem eventItem);
        Task<string> CreateLevelRecordAsync(string userName, GeneralItem eventItem);
        Task<string> CreateGearRecordAsync(string userName, GeneralItem eventItem);
        Task<string> CreateHealthRecordAsync(string userName, GeneralItem eventItem);
        Task<User> GetUserAsync(string userName);
    }
}