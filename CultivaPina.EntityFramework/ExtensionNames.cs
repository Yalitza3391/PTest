using CultivaPina.EntityFramework.Models;
using CultivaPina.EntityFramework.Models.Repositories;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivaPina.EntityFramework
{
    public static class ExtensionNames
    {
        [DbFunction("dbo.GetName", "Sector")]
        public static String GetName(this int id)
        {
            using (var db = new CultivoPinaDBContext())
            {
                var data = db.Sectors.Where(x => x.SectorId == id);
                string PinaN = data.Select(x => x.SectorNombre).FirstOrDefault();
                return PinaN;
            }
        }

        [DbFunction("dbo.GetNamePina", "Pina")]
        public static String GetNamePina(this int id)
        {
            using (var db = new CultivoPinaDBContext())
            {
                var data = db.Pina.Where(x => x.PinaId == id);
                string PinaN = data.Select(x => x.PinaNombre).FirstOrDefault();
                return PinaN;
            }
        }

        [DbFunction( "dbo.GetPinaPH","Pina")]
        public static int GetNamePinaPH(this int id)
        {
            using (var db = new CultivoPinaDBContext())
            {
                var data = db.Pina.Where(x => x.PinaId == id);
                int PinaPH = data.Select(x => x.PinaProductividadPorHectarea).FirstOrDefault();
                return PinaPH;
            }

        } 
    }
}
