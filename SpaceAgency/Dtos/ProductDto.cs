using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpaceAgency.Models;

namespace SpaceAgency.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public Decimal Price { get; set; }

        public int MissionId { get; set; }
    }
}