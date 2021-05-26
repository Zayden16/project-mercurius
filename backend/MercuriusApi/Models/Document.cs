namespace MercuriusApi.Models
{
    public class Document
    {
        public int Document_Id { get; set; }

        public int Document_Number { get; set; }

        public int Document_TypeId { get; set; }

        public int Document_CreatorId { get; set; }

        public int Document_SendeeId { get; set; }

        public int Document_StatusId { get; set; }

        public int Document_ArticlePositionId { get; set; }
    }
}
