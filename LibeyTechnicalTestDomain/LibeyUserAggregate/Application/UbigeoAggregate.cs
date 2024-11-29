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
    public class UbigeoAggregate : IUbigeoAggregate
    {
        private readonly IUbigeoRepository _ubigeoRepository;
        public UbigeoAggregate(IUbigeoRepository ubigeoRepository)
        {
            _ubigeoRepository = ubigeoRepository;
        }

        public List<UbigeoResponse> FindUbigeo(string provinciaCode,string regionCode)
        {
            return _ubigeoRepository.FindUbigeo(provinciaCode, regionCode);
        }
    }
}
