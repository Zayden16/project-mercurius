using System.Text.Json.Serialization;

namespace MercuriusApi.Models
{
    public class User
    {
        [JsonPropertyName("User_Id")]
        public int User_Id { get; set; }
        [JsonPropertyName("User_FirstName")]

        public string User_FirstName { get; set; }
        [JsonPropertyName("User_LastName")]

        public string User_LastName { get; set; }
        [JsonPropertyName("User_DisplayName")]

        public string User_DisplayName { get; set; }
        [JsonPropertyName("User_Mail")]

        public string User_Mail { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string User_Password { get; set; }
    }
}
