using System;
using MercuriusApi.Helpers;
using MercuriusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

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
                _generator.GenerateQrBillAsPdf(id);
                return Ok();
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }
    }
}