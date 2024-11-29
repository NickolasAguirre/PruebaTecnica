using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController:Controller
    {

        private readonly IRegionAggregate _regionAggregate;
        public RegionController(IRegionAggregate regionAggregate)
        {
            _regionAggregate=regionAggregate;
        }

       [HttpGet]
       public IActionResult getAllRegion()
        {
            var regions = _regionAggregate.getAllRegion();
            return Ok(regions);
        }

    }
}
