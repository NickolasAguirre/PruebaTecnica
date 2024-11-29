using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Provice
{
    [ApiController]
    [Route("[controller]")]

    public class ProvinceController : Controller
    {
        private readonly IProvinceAggregate _provinceAggregate;
        public ProvinceController(IProvinceAggregate provinceAggregate)
        {
            _provinceAggregate = provinceAggregate;
        }

        [HttpGet]
        public IActionResult FindProvinces(string regionCode)
        {
            var data = _provinceAggregate.FindProvinces(regionCode);
            return Ok(data);
        }
    }
}
