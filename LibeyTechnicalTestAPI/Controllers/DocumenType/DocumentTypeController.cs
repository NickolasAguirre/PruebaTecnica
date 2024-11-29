using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.DocumenType
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentTypeController : Controller
    {
        private readonly IDocumentTypeAggregate _documentTypeAggregate;

        public DocumentTypeController(IDocumentTypeAggregate documentTypeAggregate)
        {
            _documentTypeAggregate = documentTypeAggregate;
        }
        [HttpGet]
        public IActionResult getAllDocumentType()
        {
            List<DocumentTypeResponse> data =  _documentTypeAggregate.getAllDocumentType();
            return Ok(data);
        }
    }
}
