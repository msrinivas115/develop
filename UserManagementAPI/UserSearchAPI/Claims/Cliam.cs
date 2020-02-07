using System.Security.Claims;

namespace UserSearchAPI.Claims
{
    public class Cliam : ICliam
    {
        public string ValidateRequestParamenters()
        {
            string userName = string.Empty;
            Claim userPrincipal = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Upn);
            if (userPrincipal != null)
            {
                userName = userPrincipal.Value.Trim();
                userName = userName.Remove(userName.LastIndexOf('@'));
                userName = userName.ToLower().Replace("tsp_", string.Empty);
            }
            return userName;
        }
    }
}