using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class RegionRepository : IRegionRepository
    {
        private readonly Context _context;
        public RegionRepository(Context context)
        {
            _context = context;
        }

        public List<RegionResponse> getAllRegion()
        {
            var regions = (from re in _context.Regions
                           select new RegionResponse
                           {
                               RegionCode=re.RegionCode,
                               RegionDescription=re.RegionDescription,
                           }).ToList();
            return regions;
        }
    }
}
