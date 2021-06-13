using System.Text.Json.Serialization;

namespace MercuriusApi.Models
{
    public class Document
    {
        [JsonPropertyName("Id")]
        public int Document_Id { get; set; }

        [JsonPropertyName("Number")]
        public int Document_Number { get; set; }

        [JsonPropertyName("TypeId")]
        public int Document_TypeId { get; set; }

        [JsonPropertyName("CreatorId")]
        public int Document_CreatorId { get; set; }

        [JsonPropertyName("SendeeId")]
        public int Document_SendeeId { get; set; }

        [JsonPropertyName("StatusId")]
        public int Document_StatusId { get; set; }

        [JsonPropertyName("ArticlePositionId")]
        public int Document_ArticlePositionId { get; set; }
    }
}
