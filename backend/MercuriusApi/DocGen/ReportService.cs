using Codecrete.SwissQRBill.Generator;
using DinkToPdf;
using DinkToPdf.Contracts;
using MercuriusApi.DataAccess;

namespace MercuriusApi.DocGen
{
    public class ReportService : IReportService
    {
        private readonly IConverter _converter;
        private readonly InvoiceReport _report;
        private readonly PostgreSqlContext _context;

        public ReportService(IConverter converter, PostgreSqlContext context)
        {
            _converter = converter;
            _context = context;
            _report = new InvoiceReport(context);
        }

        public byte[] GeneratePdf(int documentId)
        {
            var html = _report.GetReport(documentId);
            var globalSettings = new GlobalSettings()
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings {Top = 25, Bottom = 0}
            };
            var objectSettings = new ObjectSettings()
            {
                PagesCount = true,
                HtmlContent = html,
                HeaderSettings = new HeaderSettings()
                {
                    FontSize = 11,
                    FontName = "Arial"
                },
                FooterSettings = new FooterSettings()
                {
                    FontSize = 11,
                    FontName = "Arial"
                },
                WebSettings = new WebSettings()
                {
                    DefaultEncoding = "utf-8",
                }
            };

            var htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = {objectSettings}
            };
            return _converter.Convert(htmlToPdfDocument);
        }
    }
}