namespace MercuriusApi.Models
{
    public class Article
    {
        public int Article_Id { get; set; }

        public string Article_Title { get; set; }

        public string Article_Description { get; set; }

        public double Article_Price { get; set; }

        public int Article_TaxRate { get; set; }

        public int Article_Unit { get; set; }
    }
}
