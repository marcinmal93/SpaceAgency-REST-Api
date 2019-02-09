using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SpaceAgency.Models;

namespace SpaceAgency.Dtos
{
    public class MissionDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public byte MissionTypeId { get; set; }

    }
}