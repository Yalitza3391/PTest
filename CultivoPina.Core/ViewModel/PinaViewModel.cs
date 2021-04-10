using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultivaPiñaWeb.ViewModel
{
    public class PinaViewModel
    {
        public int PinaId { get; set; }
        public String PinaNombre { get; set; }
        public float PinaMaduracion { get; set; }
        public int PinaProductividadPorHectarea { get; set; }
    }
}