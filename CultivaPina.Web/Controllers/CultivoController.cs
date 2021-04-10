namespace CultivaPiñaWeb.Controllers
{
    using System.Web.Mvc;
    using CultivoPina.Core.Cultivo;
    using System.Linq;
   

    public class CultivoController : Controller
    {
        private readonly ICultivo cultivoManager;
        public CultivoController(ICultivo cultivoManager)
        {
            this.cultivoManager = cultivoManager;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetSectoresProductivos()
        {
            var cultivosdata = this.cultivoManager.GetAllAsyncDate();
            var model = this.cultivoManager.GetSectoresProductivos(cultivosdata.ToList());
            return this.View(model);
        }

        public ActionResult GetCultivoProductivos()
        {
            var cultivosdata = this.cultivoManager.GetAllAsyncDate();
            var model = this.cultivoManager.GetCultivoProductivo(cultivosdata.ToList());
            return this.View(model);
        }

        public ActionResult Proyeccióndecultivos()
        {
            var cultivosdata = this.cultivoManager.GetAllAsyncDate();
            var model = this.cultivoManager.GetProyeccionCultivos(cultivosdata.ToList());
            return this.View(model);
        }

    }
}
