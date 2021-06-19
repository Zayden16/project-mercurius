using System.Text.Json.Serialization;

namespace MercuriusApi.Models
{
    public class Article
    {
        [JsonPropertyName("Id")]
        public int Article_Id { get; set; }

        [JsonPropertyName("Title")]
        public string Article_Title { get; set; }

        [JsonPropertyName("Description")]
        public string Article_Description { get; set; }

        [JsonPropertyName("Price")]
        public double Article_Price { get; set; }

        [JsonPropertyName("TaxRate")]
        public int Article_TaxRate { get; set; }

        [JsonPropertyName("Unit")]
        public int Article_Unit { get; set; }
    }
}
