using CultivaPina.EntityFramework.Models.Repositories;
using CultivoPina.Core;
using CultivoPina.Core.Sector;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivoPina.Core.Sector
{
     public class SectorManager:ISector
     {

        private readonly IRepository<CultivaPina.EntityFramework.Models.Sector> SectorRepository;
        public SectorManager(IRepository<CultivaPina.EntityFramework.Models.Sector> SectorRepository)
        {
            this.SectorRepository = SectorRepository;
        }

        public IEnumerable<CultivaPina.EntityFramework.Models.Sector> GetAllAsyncDate()
        {
            return this.SectorRepository.All().ToList();
        }

        public String FindByNameAsync(long? id)
        {
            var data = this.FindByIdAsync(id);
            return data.Result.SectorNombre;
        }

        public async Task<OperationResult> CreateAsync(CultivaPina.EntityFramework.Models.Sector sector)
        {
            if (sector == null)
            {
                throw new ArgumentNullException(nameof(sector));
            }

            if (await this.SectorRepository.FirstOrDefaultAsync(f => f.SectorId == sector.SectorId) == null)
            {
                this.SectorRepository.Create(sector);
                await this.SectorRepository.SaveChangesAsync();
                return new OperationResult(true);
            }

            return new OperationResult(new[] { $"Código {sector.SectorId} ya existe." });
        }

        public async Task<OperationResult> Edit(CultivaPina.EntityFramework.Models.Sector sector)
        {
            var foundresult = await this.SectorRepository.FindAsync(sector.SectorId);
            if (foundresult == null)
            {
                return new OperationResult(new[] { $"El {sector.SectorId} no existe." });
            }

            foundresult.SectorNombre = sector.SectorNombre;
          

            this.SectorRepository.Update(foundresult);
            await this.SectorRepository.SaveChangesAsync();
            return new OperationResult(true);
        }

        public Task<CultivaPina.EntityFramework.Models.Sector> FindByIdAsync(long? id)
        {
            return this.SectorRepository.FirstOrDefaultAsync(a => a.SectorId == id);
        }

        public async Task<OperationResult> DeleteAsync(long id)
        {
            var oldEntity = this.GetAllAsyncDate().Where(x => x.SectorId == id).FirstOrDefault();
            this.SectorRepository.Delete(oldEntity);
            await this.SectorRepository.SaveChangesAsync();
            return new OperationResult(true);
        }
    }
}
