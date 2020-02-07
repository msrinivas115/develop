using System.Configuration;

namespace Access
{
    /// <summary>
    /// CommonDL class
    /// </summary>
    public class CommonDL
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("connectionString");
            }
        }

        public static string EncryptConnectionString
        {
            get
            {
                return AES.Decrypt(ConfigurationManager.AppSettings.Get("encrpytConnectionString"), new byte[] { 1, 1, 3, 6, 2, 5, 4, 7 });
            }
        }
    }
}
