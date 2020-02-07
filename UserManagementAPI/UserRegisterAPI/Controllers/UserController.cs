using Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;
using UserRegisterAPI.Claims;

namespace UserRegisterAPI.Controllers
{
    [Authorize]
    [RoutePrefix("User/UserAPI")]
    public class UserController : ApiController
    {
        #region Variables
        private string strUserName = null;
        private readonly IUser _user;
        private readonly ICliam _utilities;
        #endregion

        #region Constructor
        public UserController(IUser user, ICliam utilities)
        {
            _user = user;
            _utilities = utilities;
        }
        #endregion

        #region User Registration
        /// <summary>
        ///  User Registration
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpPost]
        [Route("SaveUser")]
        public IHttpActionResult SaveUserInfo(JObject strUser)
        {
            try
            {
                strUserName = _utilities.ValidateRequestParamenters();
                if (string.IsNullOrEmpty(strUserName))
                {
                    return Unauthorized();
                }
                string strValue = strUser["strUser"].ToString();
                var res = _user.SaveUserDetails(strValue);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUser")]
        public IHttpActionResult GetUserInfo()
        {
            try
            {
                strUserName = _utilities.ValidateRequestParamenters();
                if (string.IsNullOrEmpty(strUserName))
                {
                    return Unauthorized();
                }
                var res = _user.GetUserInfo();
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
