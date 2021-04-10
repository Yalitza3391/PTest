


namespace CultivaPina.EntityFramework.Models.Repositories
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public class SectorRepository : CultivoPinaRepository<Sector>
    {

        public SectorRepository(CultivoPinaDBContext context)
           : base(context)
        {
        }

        public override IQueryable<Sector> All()
        {
            return this.Context.Sectors.AsNoTracking();
        }

        public override IQueryable<Sector> AllWithTracking()
        {
            return this.Context.Sectors;
        }

        protected override Sector MapNewValuesToOld(Sector oldEntity, Sector newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

