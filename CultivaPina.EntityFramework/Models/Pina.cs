using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CultivaPina.EntityFramework.Models
{
    public class Pina
    {
        [Key]
        public int PinaId { get; set; }
        public String PinaNombre { get; set; }
        public float PinaMaduracion { get; set; }
        public int PinaProductividadPorHectarea { get; set; }
    }
}
