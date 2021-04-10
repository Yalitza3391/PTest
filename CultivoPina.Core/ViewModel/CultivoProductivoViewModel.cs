using CultivaPina.EntityFramework.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CultivaPiñaWeb.ViewModel
{
    public class CultivoProductivoViewModel
    {

        public int PinaId { get; set; }
        [DisplayName("Nombre Piña")]
        public string PinaName { get; set; }
        [DisplayName("Nombre Sector")]
        public string SectorName { get; set; }
        [DisplayName("Total Productividad")]
        public double Total { get; set; }
        public int TotalCultivos { get; set; }
        public Double Productividad { get; set; }
        [DisplayName("Fecha Recoleccion")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fechaderecoleccion { get; set; }
        public String Mes { get; set; }
    }
} 