using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class ProvinceAggregate : IProvinceAggregate
    {
        private readonly IProvinceRepository _provinceRepository;

       public ProvinceAggregate(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public List<ProvinceResponse> FindProvinces(string regionCode)
        {
            return _provinceRepository.FindProvinces(regionCode);
        }
    }

}

