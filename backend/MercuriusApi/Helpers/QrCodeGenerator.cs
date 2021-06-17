using System.IO;
using System.Linq;
using Codecrete.SwissQRBill.Generator;
using MercuriusApi.DataAccess;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;


namespace MercuriusApi.Helpers
{
    public class QrCodeGenerator
    {
        private readonly PostgreSqlContext _context;

        public QrCodeGenerator(PostgreSqlContext context)
        {
            _context = context;
        }

        public MemoryStream GeneratePdf(int documentId)
        {
            var document = new PdfDocument();
            document.Info.Title = "Created with PDFSharp";

            PdfPage page = document.AddPage();
            page.Size = PageSize.A4;
            XFont titleFont = new XFont("Verdana", 32, XFontStyle.Regular);
            
            var bill = GetBill(documentId);
            using (var canvas = new PdfSharpCanvas(page, "Verdana"))
            {
                QRBill.Draw(bill, canvas);
            }
            
            XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.DrawString($"Invoice №{documentId}", titleFont, XBrushes.Black, new XRect(20, 50, 0, 0));

            var memStream = new MemoryStream();
            document.Save(memStream, false);
            return memStream;
        }

        private Bill GetBill(int documentId)
        {
            var document = _context.Document.FirstOrDefault(x => x.Document_Id == documentId);
            var sender = _context.User.FirstOrDefault(x => x.User_Id == document.Document_CreatorId);
            var receiver = _context.Customer.FirstOrDefault(x => x.Customer_Id == document.Document_SendeeId);
            var artPositions =
                _context.ArticlePosition.FirstOrDefault(x => document.Document_ArticlePositionId == x.ArticlePosition_Id);
            var plz = _context.Plz.FirstOrDefault(x => receiver.Customer_PlzId == x.Plz_Id);
            var bill = new Bill
            {
                Account = "CH4431999123000889012",
                Creditor = new Address
                {
                    Name = sender.User_FirstName + " " + sender.User_LastName,
                    AddressLine1 = "Project Mercurius",
                    AddressLine2 = "6969 Testdorf",
                    CountryCode = "CH"
                },
                Amount = 199.95m,
                Currency = "CHF",
                Debtor = new Address
                {
                    Name = receiver.Customer_FirstName + " " + receiver.Customer_LastName,
                    AddressLine1 = receiver.Customer_Address1,
                    AddressLine2 = plz.Plz_Number + " " + plz.Plz_City,
                    CountryCode = "CH"
                },
                Reference = "210000000003139471430009017",
                UnstructuredMessage = "Generated in Project Mercurius"
            };

            return bill;
        }
    }
}