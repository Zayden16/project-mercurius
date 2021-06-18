using System;
using DinkToPdf.Contracts;
using MercuriusApi.DocGen;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
    [Route("api/[controller]")]
    public class DocgenController : ControllerBase
    {
        private IConverter _converter;
        private IReportService _reportService;
        public DocgenController(IConverter converter)
        {
            _converter = converter;
            _reportService = new ReportService(_converter);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetPdf(int id)
        {
            try
            {
                var pdf = _reportService.GeneratePdf();
                return File(pdf, "application/octet-stream", $"Invoice-{id}.pdf");
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }
    }
}