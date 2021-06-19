using System;
using DinkToPdf.Contracts;
using MercuriusApi.DataAccess;
using MercuriusApi.DocGen;
using MercuriusApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusApi.Controllers
{
    [Route("api/[controller]")]
    [AuthorizationRequired]
    public class DocgenController : ControllerBase
    {
        private readonly IConverter _converter;
        private readonly IReportService _reportService;
        private readonly PostgreSqlContext _context;
        
        public DocgenController(IConverter converter, PostgreSqlContext context)
        {
            _converter = converter;
            _context = context;
            _reportService = new ReportService(_converter, _context);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetPdf(int id)
        {
            try
            {
                var pdf = _reportService.GeneratePdf(id);
                return File(pdf, "application/pdf", $"Invoice-{id}.pdf");
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }
    }
}