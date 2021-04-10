using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CultivaPina.EntityFramework.Models;
using CultivaPiñaWeb.ViewModel;

namespace CultivoPina.Core.Cultivo
{
    public interface ICultivo
    {
        IEnumerable<CultivaPina.EntityFramework.Models.Cultivo> GetAllAsyncDate();
        Task<OperationResult> CreateAsync(CultivaPina.EntityFramework.Models.Cultivo cultivo);
        Task<OperationResult> Edit(CultivaPina.EntityFramework.Models.Cultivo cultivo);
        Task<CultivaPina.EntityFramework.Models.Cultivo> FindByIdAsync(long? id);
        Task<OperationResult> DeleteAsync(long id);
        IEnumerable<CultivoProductivoViewModel> GetCultivoProductivo(List<CultivaPina.EntityFramework.Models.Cultivo> cultivo);
        IEnumerable<SectorProductivoViewModel> GetSectoresProductivos(List<CultivaPina.EntityFramework.Models.Cultivo> cultivo);
        IEnumerable<CultivoProductivoViewModel> GetProyeccionCultivos(List<CultivaPina.EntityFramework.Models.Cultivo> cultivo);
    }


}
