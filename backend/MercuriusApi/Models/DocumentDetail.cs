using System.Diagnostics.CodeAnalysis;

namespace MercuriusApi.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DocumentDetail
    {
        public int Document_Number { get; set; }
        public string User_IBAN { get; set; }
        
        public string User_RefNumber { get; set; }
        public string User_FirstName { get; set; }
        public string User_LastName { get; set; }
        public string User_Mail { get; set; }
        public string Customer_FirstName { get; set; }
        public string Customer_LastName { get; set; }
        public string Customer_Address1 { get; set; }
        public string Customer_PlzNumber { get; set; }
        public string Customer_PlzCity { get; set; }
        public decimal ArtPos_Quantity { get; set; }
        public string Art_Title { get; set; }
        
        public string Art_Description { get; set; }
        public decimal Art_Price { get; set; }
        
        public decimal TaxRate_Percentage { get; set; }
        public string ArtUnit_Text { get; set; }
    }
}