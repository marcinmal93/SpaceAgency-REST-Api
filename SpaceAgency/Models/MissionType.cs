using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceAgency.Models
{
    public class MissionType
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        public static string Panchromatic = "Panchromatic";
        public static string Multispectral = "Multispectral";
        public static string Hyperspectral = "Hyperspectral";

    }
}