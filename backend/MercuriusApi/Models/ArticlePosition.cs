using System.Text.Json.Serialization;

namespace MercuriusApi.Models
{
    public class ArticlePosition
    {
        [JsonPropertyName("Id")]
        public int ArticlePosition_Id { get; set; }

        [JsonPropertyName("ArticleId")]
        public int Article_Id { get; set; }

        [JsonPropertyName("DocumentId")]
        public int Document_Id { get; set; }

        [JsonPropertyName("Quantity")]
        public double Article_Quantity { get; set; }
    }
}
