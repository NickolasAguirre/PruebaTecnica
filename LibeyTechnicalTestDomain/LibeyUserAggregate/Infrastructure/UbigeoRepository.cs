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
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly Context _context;
        public UbigeoRepository(Context context)
        {
            _context = context;
        }

        public List<UbigeoResponse> FindUbigeo(string provinciaCode, string regionCode)
        {
            var ubigeos  = (from ub in _context.Ubigeos
                         join pro in _context.Provinces on ub.ProvinceCode equals pro.ProvinceCode
                         join reg in _context.Regions on ub.RegionCode equals reg.RegionCode
                         where pro.ProvinceCode==provinciaCode && reg.RegionCode==regionCode
                         select new UbigeoResponse
                         {
                             ProvinceCode = pro.ProvinceCode,
                             RegionCode = reg.RegionCode,
                             UbigeoCode = ub.UbigeoCode,
                             UbigeoDescription = ub.UbigeoDescription,
                             
                         }).ToList();
            return ubigeos;
        }

  
    }
}
