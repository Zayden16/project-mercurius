using System.Text.Json.Serialization;

namespace MercuriusApi.Models
{
    public class Customer
    {
        [JsonPropertyName("Id")]
        public int Customer_Id { get; set; }

        [JsonPropertyName("FirstName")]
        public string Customer_FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string Customer_LastName { get; set; }

        [JsonPropertyName("Address1")]
        public string Customer_Address1 { get; set; }

        [JsonPropertyName("Address2")]
        public string Customer_Address2 { get; set; }

        [JsonPropertyName("Email")]
        public string Customer_Email { get; set; }
        
        [JsonPropertyName("PlzId")]
        public int Customer_PlzId { get; set; }
    }
}
