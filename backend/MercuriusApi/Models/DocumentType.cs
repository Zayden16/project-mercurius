using System.Text.Json.Serialization;

namespace MercuriusApi.Models
{
    public class DocumentType
    {
        [JsonPropertyName("Id")]
        public int DocumentType_Id { get; set; }

        [JsonPropertyName("Title")]
        public string DocumentType_Title { get; set; }

        [JsonPropertyName("Description")]
        public string DocumentType_Description { get; set; }
    }
}
