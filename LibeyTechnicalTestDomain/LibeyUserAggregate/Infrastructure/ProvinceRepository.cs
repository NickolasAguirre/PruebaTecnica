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
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly Context _context;

        public ProvinceRepository(Context context)
        {
            _context = context;
        }

        public List<ProvinceResponse> FindProvinces(string regionCode)
        {
            var provinces = (from pro in _context.Provinces
                        join re in _context.Regions on pro.RegionCode equals re.RegionCode
                        where pro.RegionCode == regionCode
                        select new ProvinceResponse
                        {
                            ProvinceCode = pro.ProvinceCode,
                            RegionCode = re.RegionCode, // Asegúrate de que 'regionCode' esté en mayúscula si es la propiedad correcta
                            ProvinceDescription = pro.ProvinceDescription,
                        }).ToList();
            return provinces;
        }


    }
}
