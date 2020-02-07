using Dapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Access
{
    public class UserAccess : IUserAccess
    {
        public List<User> GetUserDetails(int countryId, string city, int paymentType)
        {
            List<User> userColl = new List<User>();
            try
            {
                string strProcedureName = "usp_GetUserDetails";
                IDbConnection db = new SqlConnection(CommonDL.EncryptConnectionString);
                using (var multipleresult = db.QueryMultiple(strProcedureName, new { CountryId = countryId, City = city, PaymentType = paymentType }, commandType: CommandType.StoredProcedure))
                {
                    userColl.AddRange(multipleresult.Read<User>().AsList());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userColl;
        }

        public bool ValidateUserEmail(string strEmail)
        {
            int i = 0;
            bool success = false;
            try
            {
                IDbConnection db = new SqlConnection(CommonDL.ConnectionString);
                var parameters = new DynamicParameters();
                parameters.Add("@EMail", strEmail);
                parameters.Add(name: "@UserId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                db.Execute("usp_ValidateUserEmail", parameters, commandType: CommandType.StoredProcedure);
                i = parameters.Get<int>("@UserId");
                if (i > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }

        public bool SaveUserDetails(User objUser)
        {
            int i = 0;
            bool success = false;
            try
            {
                IDbConnection db = new SqlConnection(CommonDL.ConnectionString);
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", objUser.UserId);
                parameters.Add("@FirstName", objUser.FirstName);
                parameters.Add("@LastName", objUser.LastName);
                parameters.Add("@EMail", objUser.Email);
                parameters.Add("@Age", objUser.Age);
                parameters.Add("@Address1", objUser.Address1);
                parameters.Add("@Address2", objUser.Address2);
                parameters.Add("@City", objUser.City);
                parameters.Add("@CountryId", objUser.CountryId);
                parameters.Add("@PaymentType", objUser.Payment);
                parameters.Add(name: "UId", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                db.Execute("usp_SaveUserDetails", parameters, commandType: CommandType.StoredProcedure);
                i = parameters.Get<int>("UId");
                if (i > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }
    }
}
