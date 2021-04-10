


namespace CultivaPiñaWeb.Controllers
{
    using System.Web.Mvc;
    using CultivoPina.Core.Cultivo;
    
    using System.Linq;
    using System;
    using CultivoPina.Core.Sector;
    using CultivaPina.EntityFramework.Models;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using CultivaPiñaWeb.ViewModel;

    public class SectorController : Controller
    {
        // GET: Sector
      
        private readonly ISector sectorManager;

        public SectorController(ISector sectorManager)
        {
            this.sectorManager= sectorManager;
            
        }

       
        public ActionResult Index()
        {
            var data= this.sectorManager.GetAllAsyncDate();
            var model = data.Select(s => new SectorViewModel
            {
                SectorId=s.SectorId,
                SectorNombre=s.SectorNombre
                

            });

            return this.View(model);
        }


        public ActionResult Create(Sector sector)
        {
            if (sector == null)
            {
                return new HttpStatusCodeResult(500);
            }

            if (this.ModelState.IsValid)
            {
                Sector sector1 = new Sector
                {
                    SectorId = sector.SectorId,
                    SectorNombre= sector.SectorNombre

                };
                try
                {
                    var created = this.sectorManager.CreateAsync(sector1);
                    if (!created.IsCompleted)
                    {
                        
                        return this.View(sector1);
                    }
                }
                catch (System.Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw;
                }

                //return this.RedirectToAction("Index");
            }

            return this.View(sector);
            
        }

        public ActionResult Edit(Sector sector)
        {
            if (sector == null)
            {
                return new HttpStatusCodeResult(500);
            }

            if (this.ModelState.IsValid)
            {
                Sector sector1 = new Sector
                {
                    SectorId = sector.SectorId,
                    SectorNombre = sector.SectorNombre

                };
                try
                {
                    var created = this.sectorManager.Edit(sector1);
                    if (!created.IsCompleted)
                    {

                        return this.View(sector1);
                    }
                }
                catch (System.Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw;
                }

                //return this.RedirectToAction("Index");
            }

            return this.View(sector);

        }

        public  ActionResult Delete(int id)
        {
            try
            {
                //var zone = await this.countryManager.FindByIdAsync(id);
                var result = this.sectorManager.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return this.RedirectToAction("IndexError", new { error = true });
            }
            return this.RedirectToAction("Index");
        }




    }
}
