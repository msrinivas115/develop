using Access;
using Entities;
using Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;

namespace Services
{
    public class UserService : IUser
    {
        #region Variables
        private readonly IUserAccess _userAccess;
        #endregion

        #region Constructors
        public UserService(IUserAccess userAccess)
        {
            _userAccess = userAccess;
        }
        #endregion

        #region Save User Details
        public string SaveUserDetails(string strJson)
        {
            User objUser = JsonConvert.DeserializeObject<User>(strJson);
            if (objUser != null)
            {
                //Validte User Email for unique user
                bool hasEmail = false;
                if(objUser.UserId <= 0)
                {
                    hasEmail = _userAccess.ValidateUserEmail(objUser.Email);
                }
                if (!hasEmail && _userAccess.SaveUserDetails(objUser))
                {
                    return ConfigurationManager.AppSettings["UserSave"];
                }
                else if(hasEmail)
                {
                    return ConfigurationManager.AppSettings["UniqueUser"];
                }
                else
                {
                    return ConfigurationManager.AppSettings["UserFial"];
                }
            }
            else
            {
                return ConfigurationManager.AppSettings["InvalidJSON"];
            }
        }
        #endregion

        #region Search User Details
        public List<User> GetUserDetails(int countryId, string city, int payment)
        {
            return _userAccess.GetUserDetails(countryId, city, payment);
        }
        #endregion

        public User GetUserInfo()
        {
            User objUser = new User();
            objUser.UserId = 1;
            objUser.FirstName = "A";
            objUser.LastName = "A";
            objUser.Email = "ab";
            objUser.Age = 3;
            objUser.Payment = PaymentInfo.Cash;
            return objUser;
        }
    }
}
