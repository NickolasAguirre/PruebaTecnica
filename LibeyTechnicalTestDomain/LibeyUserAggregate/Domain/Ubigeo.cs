using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    [Table("Ubigeo")]
    public class Ubigeo
    {
        [Key]
        public string UbigeoCode { get; set; }
        public string? ProvinceCode { get; set; }
        public string? RegionCode { get; set; }
        public string? UbigeoDescription { get; set; }

    }
}
