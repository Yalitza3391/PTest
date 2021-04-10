using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CultivaPina.EntityFramework.Models;
namespace CultivoPina.Core.Pina
{
    public interface IPina
    {
        IEnumerable<CultivaPina.EntityFramework.Models.Pina> GetAllAsyncDate();

        Task<OperationResult> CreateAsync(CultivaPina.EntityFramework.Models.Pina pina);

        Task<OperationResult> Edit(CultivaPina.EntityFramework.Models.Pina pina);

        Task<CultivaPina.EntityFramework.Models.Pina> FindByIdAsync(long? id);

        Task<OperationResult> DeleteAsync(long id);
    }
}
