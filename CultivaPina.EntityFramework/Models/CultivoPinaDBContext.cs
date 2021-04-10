using CultivaPina.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivaPina.EntityFramework.Models
{
    public class CultivoPinaDBContext: DbContext
    {
        public CultivoPinaDBContext() :  base("CultivoPina")
        {
            Database.SetInitializer<CultivoPinaDBContext>(new CultivoPinaSeedBasedeDatos());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
                   
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cultivo>().MapToStoredProcedures();
        }

        public DbSet<Pina> Pina { get; set; } 
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Cultivo> Cultivos { get; set; }

    }
}
