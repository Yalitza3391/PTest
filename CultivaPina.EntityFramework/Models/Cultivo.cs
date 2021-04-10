using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CultivaPina.EntityFramework.Models
{
    public class Cultivo
    {
        [Key]
        public int CultivoId { get; set; }
        public DateTime CultivoFechaSiembra { get; set;}
        public decimal CultivoPeso{ get; set; }
        [ForeignKey(nameof(Sector))]
        public int SectorId { get; set; }
        [ForeignKey(nameof(Pina))]
        public int PinaId { get; set; }
        public int CultivoHectareas { get; set; }
        public virtual Sector Sector{ get; set; }
        public virtual Pina  Pina { get; set; }
        public DateTime CultivoFechaRecoleccion { get; set; } 
    }
}
