using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceAgency.Models
{
    public class Product
    {
        public int Id { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public Decimal Price { get; set; }

        public Mission Mission { get; set; }

        public int MissionId { get; set; }

    }
}