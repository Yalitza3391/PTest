using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivaPina.EntityFramework.Models.Repositories
{
    public class PinaRepository : CultivoPinaRepository<Pina>
    {

        public PinaRepository(CultivoPinaDBContext context)
           : base(context)
        {
        }

        public override IQueryable<Pina> All()
        {
            return this.Context.Pina.AsNoTracking();
        }
        public override IQueryable<Pina> AllWithTracking()
        {
            return this.Context.Pina;
        }
        protected override Pina MapNewValuesToOld(Pina oldEntity, Pina newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
