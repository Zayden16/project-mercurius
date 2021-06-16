using System.IO;
using System.Linq;
using Codecrete.SwissQRBill.Generator;
using MercuriusApi.DataAccess;


namespace MercuriusApi.Helpers
{
    public class QrCodeGenerator
    {
        private readonly PostgreSqlContext _context;

        public QrCodeGenerator(PostgreSqlContext context)
        {
            _context = context;
        }

        public void GenerateQrBillAsPdf(int documentId)
        {
            var document = _context.Document.FirstOrDefault(x => x.Document_Id == documentId);
            var sender = _context.User.FirstOrDefault(x => x.User_Id == document.Document_CreatorId);
            var receiver = _context.Customer.FirstOrDefault(x => x.Customer_Id == document.Document_SendeeId);
            var artPositions =
                _context.ArticlePosition.Select(x => document.Document_ArticlePositionId == x.ArticlePosition_Id);
            Bill bill = new Bill
            {
                // creditor data
                Account = "CH4431999123000889012",
                Creditor = new Address
                {
                    Name = "Robert Schneider AG",
                    AddressLine1 = "Rue du Lac 1268/2/22",
                    AddressLine2 = "2501 Biel",
                    CountryCode = "CH"
                },

                // payment data
                Amount = 199.95m,
                Currency = "CHF",
                
                // debtor data
                Debtor = new Address
                {
                    Name = "Pia-Maria Rutschmann-Schnyder",
                    AddressLine1 = "Grosse Marktgasse 28",
                    AddressLine2 = "9400 Rorschach",
                    CountryCode = "CH"
                },

                // more payment data
                Reference = "210000000003139471430009017",
                UnstructuredMessage = "Abonnement für 2020"
            };
            /*Bill bill = new Bill
            {
                Account = "CH4431999123000889012",
                Creditor = new Address
                {
                    Name = sender.User_FirstName + sender.User_LastName,
                    PostalCode = "6004",
                    Town = "Luzern",
                    CountryCode = "CH"
                },
                Amount = 199.95m,
                Currency = "CHF",
                Debtor = new Address
                {
                    Name = receiver.Customer_FirstName + receiver.Customer_LastName,
                    AddressLine1 = receiver.Customer_Address1,
                    AddressLine2 = receiver.Customer_Address2,
                    PostalCode = _context.Plz.FirstOrDefault(x => x.Plz_Id == receiver.Customer_PlzId)?.ToString(),
                    CountryCode = "CH"
                },
                Reference = "210000000003139471430009017",
                UnstructuredMessage = "Abonnement für 2020"
            };*/
            byte[] svg = QRBill.Generate(bill);
            const string path = "qrbill.svg";
            File.WriteAllBytes(path, svg);
        }
    }
}