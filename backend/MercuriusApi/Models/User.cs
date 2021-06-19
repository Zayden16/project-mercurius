using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MercuriusApi.Models
{
    public class User
    {
        [JsonPropertyName("Id")]
        public int User_Id { get; set; }

        [MaxLength(34)]
        [JsonPropertyName("IBAN")]
        public string User_IBAN { get; set; }

        [MaxLength(27)]
        [JsonPropertyName("ReferenceNumber")]
        public string User_ReferenceNumber { get; set; }

        [JsonPropertyName("FirstName")]
        public string User_FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string User_LastName { get; set; }

        [JsonPropertyName("DisplayName")]
        public string User_DisplayName { get; set; }

        [JsonPropertyName("Mail")]
        public string User_Mail { get; set; }
        
        [Newtonsoft.Json.JsonIgnore]
        [JsonPropertyName("Password")]
        public string User_Password { get; set; }
    }
}
