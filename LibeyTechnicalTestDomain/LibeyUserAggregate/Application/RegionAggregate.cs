using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class RegionAggregate : IRegionAggregate
    {
        private readonly IRegionRepository _repository;
        public RegionAggregate(IRegionRepository repository)
        {
            _repository = repository;
        }
        public List<RegionResponse> getAllRegion()
        {
            var regions = _repository.getAllRegion();
            return regions;
        }
    }
}
