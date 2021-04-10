using CultivaPina.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivaPina.EntityFramework
{
    public class CultivoPinaSeedBasedeDatos: DropCreateDatabaseAlways<CultivaPina.EntityFramework.Models.CultivoPinaDBContext>
    {
        protected override void Seed(CultivaPina.EntityFramework.Models.CultivoPinaDBContext context)
        {
            IList<CultivaPina.EntityFramework.Models.Pina> Pina = new List<CultivaPina.EntityFramework.Models.Pina>();

            Pina.Add(new Models.Pina() { PinaId = 1, PinaNombre = "PinaA", PinaMaduracion = 1, PinaProductividadPorHectarea=  10 });
            Pina.Add(new Models.Pina() { PinaId = 2, PinaNombre = "PinaB", PinaMaduracion = 2, PinaProductividadPorHectarea = 20 });
            Pina.Add(new Models.Pina() { PinaId = 3, PinaNombre = "PinaC", PinaMaduracion = 3, PinaProductividadPorHectarea = 30 });
            Pina.Add(new Models.Pina() { PinaId = 4, PinaNombre = "PinaD", PinaMaduracion = 4, PinaProductividadPorHectarea = 40 });
            Pina.Add(new Models.Pina() { PinaId = 5, PinaNombre = "PinaE", PinaMaduracion = 4, PinaProductividadPorHectarea = 50 });

            context.Pina.AddRange(Pina);

            IList<CultivaPina.EntityFramework.Models.Sector> sectors = new List<CultivaPina.EntityFramework.Models.Sector>();

            sectors.Add(new Models.Sector() { SectorId = 1, SectorNombre = "Sector1" });
            sectors.Add(new Models.Sector() { SectorId = 2, SectorNombre = "Sector2" });
            sectors.Add(new Models.Sector() { SectorId = 3, SectorNombre = "Sector3" });
            sectors.Add(new Models.Sector() { SectorId = 4, SectorNombre = "Sector4" });
            sectors.Add(new Models.Sector() { SectorId = 5, SectorNombre = "Sector5" });
            sectors.Add(new Models.Sector() { SectorId = 6, SectorNombre = "Sector6" });
            sectors.Add(new Models.Sector() { SectorId = 7, SectorNombre = "Sector7" });
            sectors.Add(new Models.Sector() { SectorId = 8, SectorNombre = "Sector8" });
            sectors.Add(new Models.Sector() { SectorId = 9, SectorNombre = "Sector9" });

            context.Sectors.AddRange(sectors);

            
            IList<CultivaPina.EntityFramework.Models.Cultivo> cultivos = new List<CultivaPina.EntityFramework.Models.Cultivo>();

            cultivos.Add(new Models.Cultivo() { CultivoId=  1, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5) ,CultivoFechaSiembra=  DateTime.Now, SectorId=1 ,PinaId=1, CultivoHectareas=100, CultivoPeso=20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 2, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 3, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 4, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 5, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 6, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 7, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso =20 });           
            cultivos.Add(new Models.Cultivo() { CultivoId = 8, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 3, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 9, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 2, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 10, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 3, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 11, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 3, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 12, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 105, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 13, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 106, CultivoPeso = 30 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 14, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 50 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 15, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 60 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 16, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 4, CultivoHectareas = 100, CultivoPeso = 50 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 17, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 50 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 18, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 27 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 19, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 25 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 20, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 3, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            
            cultivos.Add(new Models.Cultivo() { CultivoId = 21, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 101, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 22, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 111, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 23, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 2, PinaId = 1, CultivoHectareas = 120, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 24, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 2, PinaId = 1, CultivoHectareas = 110, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 31, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 32, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 33, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 101, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 34, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 102, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 35, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 103, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 36, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 2, CultivoHectareas = 104, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 37, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 105, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 38, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 39, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 40, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 5, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 41, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 5, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 42, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 5, PinaId = 1, CultivoHectareas = 105, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 43, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 5, PinaId = 1, CultivoHectareas = 106, CultivoPeso = 30 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 44, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 5, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 50 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 45, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 5, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 60 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 46, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 5, PinaId = 1, CultivoHectareas = 10, CultivoPeso = 50 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 47, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 5, PinaId = 1, CultivoHectareas = 17, CultivoPeso = 50 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 48, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 5, PinaId = 1, CultivoHectareas = 16, CultivoPeso = 27 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 49, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 25 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 50, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 3, PinaId = 1, CultivoHectareas = 15, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 51, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 10, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 52, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra  = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 60, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 53, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now,SectorId = 2, PinaId = 5, CultivoHectareas = 120, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 54, CultivoFechaRecoleccion = DateTime.Now.AddDays(-20), CultivoFechaSiembra = DateTime.Now, SectorId = 2, PinaId = 5, CultivoHectareas = 11, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 49, CultivoFechaRecoleccion = DateTime.Now.AddDays(-20), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 25 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 50, CultivoFechaRecoleccion = DateTime.Now.AddDays(-20), CultivoFechaSiembra = DateTime.Now, SectorId = 3, PinaId = 1, CultivoHectareas = 15, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 51, CultivoFechaRecoleccion = DateTime.Now.AddDays(-2), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 3, CultivoHectareas = 10, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 52, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 60, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 53, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 2, PinaId = 5, CultivoHectareas = 120, CultivoPeso = 20 });
            cultivos.Add(new Models.Cultivo() { CultivoId = 54, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 2, PinaId = 5, CultivoHectareas = 11, CultivoPeso = 20 });
            
            context.Cultivos.AddRange(cultivos);
            
            base.Seed(context);
            
        }


    }
}
