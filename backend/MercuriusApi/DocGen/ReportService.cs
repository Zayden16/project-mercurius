using System.IO;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace MercuriusApi.DocGen
{
    public class ReportService : IReportService
    {
        private readonly IConverter _converter;
        private readonly InvoiceReport _report;

        public ReportService(IConverter converter)
        {
            _converter = converter;
            _report = new InvoiceReport();
        }

        public byte[] GeneratePdf()
        {
            var html = _report.GetReport();
            GlobalSettings globalSettings = new GlobalSettings()
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings {Top = 25, Bottom = 25}
            };
            ObjectSettings objectSettings = new ObjectSettings()
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