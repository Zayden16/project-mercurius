using System.Text.Json.Serialization;

namespace MercuriusApi.Models
{
    public class TaxRate
    {
        [JsonPropertyName("Id")]
        public int Taxrate_Id { get; set; }

        [JsonPropertyName("Percentage")]
        public double Taxrate_Percentage { get; set; }

        [JsonPropertyName("Description")]
        public string Taxrate_Description { get; set; }
    }
}
