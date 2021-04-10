using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivaPina.EntityFramework.Models.Repositories
{
       public abstract class CultivoPinaRepository<TEntity> : RepositoryBase<TEntity, CultivoPinaDBContext>
       where TEntity : class
       {
            public CultivoPinaRepository(CultivoPinaDBContext context)
                : base(context)
            {
                this.Context = context;
            }
       }
}
