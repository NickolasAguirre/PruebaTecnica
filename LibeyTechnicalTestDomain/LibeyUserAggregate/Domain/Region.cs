﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    [Table("Region")]
    public class Region
    {
        [Key]
        public string RegionCode { get; set; }
        public string? RegionDescription { get; set; }

    }
}
