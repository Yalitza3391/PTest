


namespace CultivaPiñaWeb.Controllers
{
    using System.Web.Mvc;
    using CultivoPina.Core.Cultivo;
    using CultivaPiñaWeb.ViewModel;
    using System.Linq;
    using System;
    using CultivoPina.Core.Pina;
    using CultivaPina.EntityFramework.Models;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class PinaController : Controller
    {
        // GET: Cultivo
      
        private readonly IPina pinaManager;

        public PinaController(IPina pinaManager)
        {
            this.pinaManager = pinaManager;
            
        }

       
        public ActionResult Index()
        {
            var data= this.pinaManager.GetAllAsyncDate();

            var model = data.Select(s => new PinaViewModel
            {
               PinaId= s.PinaId,
               PinaNombre=s.PinaNombre,
               PinaMaduracion=s.PinaMaduracion,
               PinaProductividadPorHectarea=s.PinaProductividadPorHectarea

            });
            return this.View(model);
        }

        public ActionResult Create(Pina Pina)
        {
            if (Pina == null)
            {
                return new HttpStatusCodeResult(500);
            }

            if (this.ModelState.IsValid)
            {
                Pina Pina1 = new Pina
                {
                    PinaId = Pina.PinaId,
                    PinaNombre = Pina.PinaNombre,
                    PinaMaduracion=Pina.PinaMaduracion,
                    PinaProductividadPorHectarea=Pina.PinaProductividadPorHectarea

                };
                try
                {
                    var created = this.pinaManager.CreateAsync(Pina1);
                    if (!created.IsCompleted)
                    {

                        return this.View(Pina1);
                    }
                }
                catch (System.Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw;
                }

                //return this.RedirectToAction("Index");
            }

            return this.View(Pina);

        }

        public ActionResult Edit(Pina Pina)
        {
            if (Pina == null)
            {
                return new HttpStatusCodeResult(500);
            }

            if (this.ModelState.IsValid)
            {
                Pina Pina1 = new Pina
                {
                    PinaId = Pina.PinaId,
                    PinaNombre = Pina.PinaNombre,
                    PinaMaduracion = Pina.PinaMaduracion,
                    PinaProductividadPorHectarea = Pina.PinaProductividadPorHectarea

                };
                try
                {
                    var created = this.pinaManager.Edit(Pina1);
                    if (!created.IsCompleted)
                    {

                        return this.View(Pina1);
                    }
                }
                catch (System.Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw;
                }

                //return this.RedirectToAction("Index");
            }

            return this.View(Pina);

        }

        public ActionResult Delete(int id)
        {
            try
            {
                //var zone = await this.countryManager.FindByIdAsync(id);
                var result =  this.pinaManager.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return this.RedirectToAction("IndexError", new { error = true });
            }
            return this.RedirectToAction("Index");
        }



    }
}
