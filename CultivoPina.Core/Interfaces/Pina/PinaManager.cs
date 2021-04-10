using CultivaPina.EntityFramework.Models.Repositories;
using CultivoPina.Core;
using CultivoPina.Core.Pina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivoPina.Core.Pina
{
    public class PinaManager:IPina
    {

        private readonly IRepository<CultivaPina.EntityFramework.Models.Pina> PinaRepository;
        public PinaManager(IRepository<CultivaPina.EntityFramework.Models.Pina> PinaRepository)
        {
            this.PinaRepository = PinaRepository;
        }

        public IEnumerable<CultivaPina.EntityFramework.Models.Pina> GetAllAsyncDate()
        {
            return this.PinaRepository.All().ToList();
        }

        public async Task<OperationResult> CreateAsync(CultivaPina.EntityFramework.Models.Pina Pina)
        {
            if (Pina == null)
            {
                throw new ArgumentNullException(nameof(Pina));
            }

            if (await this.PinaRepository.FirstOrDefaultAsync(f => f.PinaId == Pina.PinaId) == null)
            {
                this.PinaRepository.Create(Pina);
                await this.PinaRepository.SaveChangesAsync();
                return new OperationResult(true);
            }

            return new OperationResult(new[] { $"Código {Pina.PinaId} ya existe." });
        }

        public async Task<OperationResult> Edit(CultivaPina.EntityFramework.Models.Pina Pina)
        {
            var foundresult = await this.PinaRepository.FindAsync(Pina.PinaId);
            if (foundresult == null)
            {
                return new OperationResult(new[] { $"El {Pina.PinaId} no existe." });
            }

            foundresult.PinaNombre = Pina.PinaNombre;
            foundresult.PinaMaduracion = Pina.PinaMaduracion;
            foundresult.PinaProductividadPorHectarea = Pina.PinaProductividadPorHectarea;
            
          

            this.PinaRepository.Update(foundresult);
            await this.PinaRepository.SaveChangesAsync();
            return new OperationResult(true);
        }

        public Task<CultivaPina.EntityFramework.Models.Pina> FindByIdAsync(long? id)
        {
            return this.PinaRepository.FirstOrDefaultAsync(a => a.PinaId == id);
        }

        public async Task<OperationResult> DeleteAsync(long id)
        {
            var oldEntity = this.GetAllAsyncDate().Where(x => x.PinaId == id).FirstOrDefault();
            this.PinaRepository.Delete(oldEntity);
            await this.PinaRepository.SaveChangesAsync();
            return new OperationResult(true);
        }

        public String FindByNameAsync(long? id)
        {
            var data = this.FindByIdAsync(id);
            return data.Result.PinaNombre;
        }

    }
}
