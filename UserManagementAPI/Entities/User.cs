using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City  { get; set; }

        public int CountryId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentInfo Payment { get; set; }
    }

    public enum PaymentInfo
    {
        Cash = 1,
        Wallent = 2,
        Online = 3
    }
}
