using Entities;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IUser
    {
        string SaveUserDetails(string strJson);

        List<User> GetUserDetails(int countryId, string city, int payment);

        User GetUserInfo();
    }
}
