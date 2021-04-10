using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CultivaPina.EntityFramework.Models
{
    public class Sector
    {
        [Key]
        public int SectorId { get; set; }
        public String SectorNombre { get; set; }   
    }
}
