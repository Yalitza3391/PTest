using CultivoPina.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivoPina.Core.Sector
{
    public interface ISector
    {
        IEnumerable<CultivaPina.EntityFramework.Models.Sector> GetAllAsyncDate();

        Task<OperationResult> CreateAsync(CultivaPina.EntityFramework.Models.Sector sector);

        Task<OperationResult> Edit(CultivaPina.EntityFramework.Models.Sector sector);

        Task<CultivaPina.EntityFramework.Models.Sector> FindByIdAsync(long? id);

        Task<OperationResult> DeleteAsync(long id);
    }
}
