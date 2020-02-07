using Interfaces;
using System;
using System.Web.Http;
using UserSearchAPI.Claims;

namespace UserSearchAPI.Controllers
{
    [Authorize]
    [RoutePrefix("User/SearchAPI")]
    public class UserSearchController : ApiController
    {
        #region Variables
        private string strUserName = null;
        private readonly IUser _user;
        private readonly ICliam _utilities;
        #endregion

        #region Constructor
        public UserSearchController(IUser user, ICliam utilities)
        {
            _user = user;
            _utilities = utilities;
        }
        #endregion

        #region User Search API
        /// <summary>
        ///  User Search
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpPost]
        [Route("GetUserDetails")]
        public IHttpActionResult GetUserDetails(int countryId, string city = "", int payment = -1)
        {
            try
            {
                strUserName = _utilities.ValidateRequestParamenters();
                if (string.IsNullOrEmpty(strUserName))
                {
                    return Unauthorized();
                }
                var res = _user.GetUserDetails(countryId, city, payment);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
