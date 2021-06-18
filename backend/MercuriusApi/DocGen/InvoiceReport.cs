using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecrete.SwissQRBill.Generator;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MercuriusApi.DocGen
{
    public class InvoiceReport
    {
        private readonly PostgreSqlContext _context;

        public InvoiceReport(PostgreSqlContext context)
        {
            _context = context;
        }

        public string GetReport(int documentId)
        {
            var positions = GetDocumentView(documentId).ToList();
            var sb = new StringBuilder();
            sb.Append($@"
              <html lang='en'>
              <head>
                <meta charset='UTF-8'>
                <link rel='preconnect' href='https://fonts.gstatic.com'>
              <link href='https://fonts.googleapis.com/css2?family=Roboto&display=swap' rel='stylesheet'>
                <title>Invoice</title>
                <style>
                  *{{
                    font-family: 'Roboto', sans-serif;
                  }}
                  table{{
                    border: 1px solid;
                    width: 95%;
                  }}
                  th, td{{
                    padding: 5px;
                    text-align: left;
                  }}
                  th{{
                    color: white;
                    background-color: #212226;
                  }}
                  .svg{{
                    position: absolute;
                    bottom: 0;
                    left: 0;
                  }}
                </style>
              </head>
              <body>
                <h1>Invoice Number {documentId}</h1>
                <p>{positions[0].Customer_FirstName} {positions[0].Customer_LastName}</p>
                <p>{positions[0].Customer_Address1}</p>
                <p>{positions[0].Customer_PlzNumber} {positions[0].Customer_PlzCity}</p>
                <table>
                  <tr>
                    <th>Article</th>
                    <th>Quantity</th>
                    <th>Unit</th>
                    <th>Price</th
                  </tr>
            ");
            foreach (var position in positions)
            {
                sb.Append($@"
              <tr>
                <td>{position.Art_Title}</td>
                <td>{position.ArtUnit_Text}</td>
                <td>{position.ArtPos_Quantity}</td>
                <td>{position.Art_Price}</td>
              <tr>
          ");
            }

            sb.Append($"</table>");
            sb.Append($"<div class='svg'>");
            sb.Append(GenerateQrSvg(positions));
            sb.Append($"</div>");
            sb.Append(@"
                 </body>
               </html>
            ");
            return sb.ToString();
        }

        private string GenerateQrSvg(List<DocumentDetail> positions)
        {
            var context = positions.FirstOrDefault();

            if (context == null)
                return string.Empty;

            var bill = new Bill
            {
                Account = context.User_IBAN,
                Creditor = new Address
                {
                    Name = context.User_FirstName + context.User_LastName,
                    AddressLine1 = context.User_Mail,
                    AddressLine2 = "6004 Luzern",
                    CountryCode = "CH"
                },
                Amount = CalculateSum(positions),
                Currency = "CHF",
                Debtor = new Address
                {
                    Name = context.Customer_FirstName + context.Customer_LastName,
                    AddressLine1 = context.Customer_Address1,
                    AddressLine2 = context.Customer_PlzNumber + " " + context.Customer_PlzCity,
                    CountryCode = "CH"
                },
                UnstructuredMessage = "Generated in Project Mercurius"
            };

            var svg = QRBill.Generate(bill);
            var result = Encoding.UTF8.GetString(svg);

            return result;
        }

        private IEnumerable<DocumentDetail> GetDocumentView(int documentId)
        {
            return _context.DocumentDetail.FromSqlInterpolated($"SELECT * FROM GetDocumentView({documentId})");
        }

        private decimal CalculateSum(List<DocumentDetail> positions)
        {
            var total = 0m;
            foreach (var position in positions)
            {
                var positionTotal = position.Art_Price * position.ArtPos_Quantity;
                total += positionTotal;
            }
            return total;
        }
    }
}