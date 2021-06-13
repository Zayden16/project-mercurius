using System.Text.Json.Serialization;

namespace MercuriusApi.Models
{
    public class Plz
    {
        [JsonPropertyName("Id")]
        public int Plz_Id { get; set; }

        [JsonPropertyName("Number")]
        public string Plz_Number { get; set; }

        [JsonPropertyName("City")]
        public string Plz_City { get; set; }
    }
}
