using CultivaPina.EntityFramework.Models;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace CultivaPiñaWeb.ViewModel
{
    public class CultivoViewModel
    {
        public int CultivoId { get; set; }
        public DateTime CultivoFechaSiembra { get; set; }
        public decimal CultivoPeso { get; set; }
        public DateTime CultivoFechaRecoleccion { get; set; }
        public int SectorId { get; set; }
        public int PinaId { get; set; }
        public string SectorName{ get; set; }
        public string PinaName { get; set; }
        public int CultivoHectareas { get; set; }
        public Double Productividad { get; set; }
    }
}