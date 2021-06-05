using Newtonsoft.Json;

namespace MercuriusApi.Models
{
    public class User
    {
        public int User_Id { get; set; }

        public string User_FirstName { get; set; }

        public string User_LastName { get; set; }

        public string User_DisplayName { get; set; }

        public string User_Mail { get; set; }

        [JsonIgnore]
        public string User_Password { get; set; }
    }
}
