using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Ubigeo
{
    [ApiController]
    [Route("[controller]")]
    public class UbigeoController : Controller
    {
        private readonly IUbigeoAggregate _ubigeoAggregate;
        public UbigeoController(IUbigeoAggregate ubigeoAggregate)
        {
            _ubigeoAggregate = ubigeoAggregate;
        }

        [HttpGet]
        public IActionResult GetAllUgigeo(string provinciaCode, string regionCode)
        {
            var ubigeos = _ubigeoAggregate.FindUbigeo( provinciaCode, regionCode);
            return Ok(ubigeos);
        }
    }
}

