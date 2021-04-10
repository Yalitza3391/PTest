using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivaPina.EntityFramework.Models.Repositories
{
    public class CultivoRepository : CultivoPinaRepository<Cultivo>
    {

        public CultivoRepository(CultivoPinaDBContext context)
           : base(context)
        {
        }

        public override IQueryable<Cultivo> All()
        {
            return this.Context.Cultivos.AsNoTracking();
        }

        public override IQueryable<Cultivo> AllWithTracking()
        {
            return this.Context.Cultivos;
        }

        protected override Cultivo MapNewValuesToOld(Cultivo oldEntity, Cultivo newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
