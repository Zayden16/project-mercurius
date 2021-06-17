using System;
using System.Net;
using System.Net.Http;
using MercuriusApi.Helpers;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ContentDispositionHeaderValue = System.Net.Http.Headers.ContentDispositionHeaderValue;

namespace MercuriusApi.Controllers
{
    [Route("api/[controller]")]
    public class DocgenController : ControllerBase
    {
        private readonly QrCodeGenerator _generator;
        
        public DocgenController(QrCodeGenerator generator)
        {
            _generator = generator;
        }
        
        //[HttpGet("{id}")]
        [HttpGet("{id}")]
        public IActionResult GetPdf(int id)
        {
            try
            {
                var stream = _generator.GeneratePdf(id);
                return new FileStreamResult(stream, "application/pdf");
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }
    }
}