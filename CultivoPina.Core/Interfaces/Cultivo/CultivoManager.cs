using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CultivaPina.EntityFramework.Models.Repositories;
using CultivaPiñaWeb.ViewModel;

namespace CultivoPina.Core.Cultivo
{
    public class CultivoManage : ICultivo
    {

        private readonly IRepository<CultivaPina.EntityFramework.Models.Cultivo> CultivoRepository;
        public CultivoManage(IRepository<CultivaPina.EntityFramework.Models.Cultivo> CultivoRepository)
        {
            this.CultivoRepository = CultivoRepository;
        }


        public IEnumerable<CultivoProductivoViewModel> GetCultivoProductivo(List<CultivaPina.EntityFramework.Models.Cultivo> cultivo)
        {
            var model = ReporteExtension.CultivosProductivos(cultivo);
            return model;
        }

        public IEnumerable<SectorProductivoViewModel> GetSectoresProductivos(List<CultivaPina.EntityFramework.Models.Cultivo> cultivo)
        {
            var model = ReporteExtension.SectoresProductivos(cultivo);
            return model;
        }

        public IEnumerable<CultivoProductivoViewModel> GetProyeccionCultivos(List<CultivaPina.EntityFramework.Models.Cultivo> cultivo)
        {
            var model = ReporteExtension.ProyecciondeCultivo(cultivo);
            return model;
        }

       
        public IEnumerable<CultivaPina.EntityFramework.Models.Cultivo> GetAllAsyncDate()
        {
            return this.CultivoRepository.All().ToList();
        }

        public async Task<OperationResult> CreateAsync(CultivaPina.EntityFramework.Models.Cultivo cultivo)
        {
            if (cultivo == null)
            {
                throw new ArgumentNullException(nameof(cultivo));
            }

            if (await this.CultivoRepository.FirstOrDefaultAsync(f => f.CultivoId == cultivo.CultivoId) == null)
            {
                this.CultivoRepository.Create(cultivo);
                await this.CultivoRepository.SaveChangesAsync();
                return new OperationResult(true);
            }

            return new OperationResult(new[] { $"Código {cultivo.CultivoId} ya existe." });
        }

        public async Task<OperationResult> Edit(CultivaPina.EntityFramework.Models.Cultivo cultivo)
        {
            var foundresult = await this.CultivoRepository.FindAsync(cultivo.CultivoId);
            if (foundresult == null)
            {
                return new OperationResult(new[] { $"El {cultivo.CultivoId} no existe." });
            }

            foundresult.CultivoFechaSiembra = cultivo.CultivoFechaSiembra;
            foundresult.CultivoPeso = cultivo.CultivoPeso;
            foundresult.CultivoHectareas = cultivo.CultivoHectareas;
            foundresult.PinaId = cultivo.PinaId;
            foundresult.SectorId = foundresult.SectorId;
            foundresult.CultivoFechaRecoleccion = cultivo.CultivoFechaSiembra.AddDays(cultivo.Pina.PinaMaduracion);

            this.CultivoRepository.Update(foundresult);
            await this.CultivoRepository.SaveChangesAsync();
            return new OperationResult(true);
        }

        public Task<CultivaPina.EntityFramework.Models.Cultivo> FindByIdAsync(long? id)
        {
            return this.CultivoRepository.FirstOrDefaultAsync(a => a.CultivoId == id);
        }

        public async Task<OperationResult> DeleteAsync(long id)
        {
            var oldEntity = this.GetAllAsyncDate().Where(x => x.CultivoId == id).FirstOrDefault();
            this.CultivoRepository.Delete(oldEntity);
            await this.CultivoRepository.SaveChangesAsync();
            return new OperationResult(true);
        }

      

    }



}
