using System.Text;

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
                    background-color: #212226;
                  }
                </style>
              </head>
              <body>
                <h1>Invoice Number {documentNr}</h1>
                <p>{customerName}</p>
                <p>{cusomterAddress1}</p>
                <p>{customerAddress2}</p>
                <table>
                  <tr>
                    <th>Article</th>
                    <th>Article</th>
                    <th>Article</th>
                  </tr>
            ");
            
            sb.Append(@"
                    </body>
                </html>
            ");
            return sb.ToString();
        }
    }
}