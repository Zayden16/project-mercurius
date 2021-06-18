using System.Text;
using Codecrete.SwissQRBill.Generator;

namespace MercuriusApi.DocGen
{
    public class InvoiceReport
    {
        public string GetReport()
        {
            var sb = new StringBuilder();
            sb.Append(@"
              <html lang='en'>
              <head>
                <meta charset='UTF-8'>
                <link rel='preconnect' href='https://fonts.gstatic.com'>
              <link href='https://fonts.googleapis.com/css2?family=Roboto&display=swap' rel='stylesheet'>
                <title>Invoice</title>
                <style>
                  *{
                    font-family: 'Roboto', sans-serif;
                  }
                  table{
                    border: 1px solid;
                    width: 95%;
                  }
                  th, td{
                    padding: 5px;
                    text-align: left;
                  }
                  th{
                    color: white;
                    background-color: #212226;
                  }
                </style>
              </head>
              <body>
                <h1>Invoice Number {documentNr}</h1>
                <p>{customerName}</p>
                <p>{customerAddress1}</p>
                <p>{customerAddress2}</p>
                <table>
                  <tr>
                    <th>Article</th>
                    <th>Quantity</th>
                    <th>Unit</th>
                    <th>Price</th
                  </tr>
            ");
            sb.Append(GenerateQrSvg(1));
            sb.Append(@"
                    </body>
                </html>
            ");
            return sb.ToString();
        }
        
        private string GenerateQrSvg(int documentId)
        {
          var bill = new Bill
          {
            Account = "CH4431999123000889012",
            Creditor = new Address
            {
              Name = "Robert Schneider AG",
              AddressLine1 = "Rue du Lac 1268/2/22",
              AddressLine2 = "2501 Biel",
              CountryCode = "CH"
            },
            Amount = 199.95m,
            Currency = "CHF",
            Debtor = new Address
            {
              Name = "Pia-Maria Rutschmann-Schnyder",
              AddressLine1 = "Grosse Marktgasse 28",
              AddressLine2 = "9400 Rorschach",
              CountryCode = "CH"
            },
            Reference = "210000000003139471430009017",
            UnstructuredMessage = "Abonnement für 2020"
          };
          var svg = QRBill.Generate(bill);
          var result = Encoding.UTF8.GetString(svg);
          return result;
        }
    }
}