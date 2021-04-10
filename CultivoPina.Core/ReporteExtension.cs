using CultivaPina.EntityFramework;
using CultivaPina.EntityFramework.Models;
using CultivaPina.EntityFramework.Models.Repositories;
using CultivaPiñaWeb.ViewModel;
using CultivoPina.Core.Cultivo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CultivoPina.Core
{
    
    public static class ReporteExtension
    {
        public static IEnumerable<CultivoProductivoViewModel> CultivosProductivos(this IEnumerable<CultivaPina.EntityFramework.Models.Cultivo> items)
        {

            var results = items.GroupBy(r => r.PinaId, (key, g) => new { PinaId = key, Cultivos = g });
            var model = results.Select(s => new CultivoProductivoViewModel
            {
                PinaId = s.PinaId,
                PinaName = ExtensionNames.GetNamePina(s.PinaId),
                Total = s.Cultivos.Select(pr => new { pr = ProductividadCultivo(pr) }).Sum(x => x.pr),
                TotalCultivos = s.Cultivos.Count()
            }).ToList().OrderByDescending(x => x.Total).Take(5);

            return model;

        }

        public static IEnumerable<SectorProductivoViewModel> SectoresProductivos(this IEnumerable<CultivaPina.EntityFramework.Models.Cultivo> items)
        {           
            var results = items.GroupBy(r => r.SectorId, (key, g) => new { SectorId = key, Cultivos = g });
            var model = results.Select(s => new SectorProductivoViewModel
            {
                SectorId = s.SectorId,
                SectorName = ExtensionNames.GetName(s.SectorId),
                Total = s.Cultivos.Select(pr => new { pr = ProductividadCultivo(pr) }).Sum(x => x.pr),
                TotalCultivos = s.Cultivos.Count()
            }).ToList().OrderByDescending(x => x.Total).Take(5); 
            return model;

        }

        public static IEnumerable<CultivoProductivoViewModel> ProyecciondeCultivo(this IEnumerable<CultivaPina.EntityFramework.Models.Cultivo> items)
        {
            var cultivosmasP =items.Where(x => x.CultivoFechaRecoleccion <= DateTime.Today.Date   )
                .GroupBy(x => new { x.PinaId, x.CultivoFechaRecoleccion.Month,
                    x.SectorId}, (key, g) => new { PinaId = key.PinaId, FechaR=key.Month, 
                    SectorId= key.SectorId, Cultivos = g }).ToList();

            var model = cultivosmasP.Select(s => new CultivoProductivoViewModel
            {
                PinaId = s.PinaId,
                PinaName = ExtensionNames.GetNamePina(s.PinaId),
                SectorName = ExtensionNames.GetName(s.SectorId),
                Total = PromedioProSector(s.Cultivos.ToList()),
                TotalCultivos = s.Cultivos.Count(),
                Mes= CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(s.FechaR)
            }).ToList().OrderByDescending(x=> x.Total).Take(5);

            return model;

        }

        public static double ProductividadCultivo(this CultivaPina.EntityFramework.Models.Cultivo cultivo)
        {
            
            var PinaPH = ExtensionNames.GetNamePinaPH(cultivo.PinaId);
            double procultivo = Convert.ToDouble((((cultivo.CultivoPeso) / (cultivo.CultivoHectareas)) * 100) / PinaPH);

            return procultivo;
        }
        public static double PromedioProSector(this List<CultivaPina.EntityFramework.Models.Cultivo> cultivos)

        {
           
            double Total = cultivos.Select(pr => new { pr = ProductividadCultivo(pr) }).Average(x => x.pr);
            return Total;
        }


       

    }
}
