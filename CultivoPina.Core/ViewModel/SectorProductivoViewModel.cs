using CultivaPina.EntityFramework.Models;
//using CultivoPina.Core.Cultivo;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace CultivaPiñaWeb.ViewModel
{
    public class SectorProductivoViewModel
    {

        public int SectorId { get; set; }
        public string SectorName{ get; set; }
        public string PinaName { get; set; }
        public double Total { get; set; }
        public int TotalCultivos { get; set; }
        public Double Productividad { get; set; }
        public Double PromedioProductividad { get; set; }
    }
}