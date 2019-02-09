using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceAgency.Models
{
    public class Mission
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public byte MissionTypeId { get; set; }

        public MissionType MissionType { get; set; }
       
    }
}