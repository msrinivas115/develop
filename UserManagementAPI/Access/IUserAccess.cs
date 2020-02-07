using Entities;
using System.Collections.Generic;

namespace Access
{
    public interface IUserAccess
    {
        bool SaveUserDetails(User objUser);

        bool ValidateUserEmail(string strEmail);

        List<User> GetUserDetails(int countryId, string city, int payment);
    }
}
