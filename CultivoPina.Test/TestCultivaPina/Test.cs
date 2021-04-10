using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CultivaPina.EntityFramework;
using CultivaPina.EntityFramework.Models;
using CultivaPiñaWeb.Controllers;
using CultivaPiñaWeb.ViewModel;
using CultivoPina.Core;
using CultivoPina.Core.Cultivo;
using CultivoPina.Core.Sector;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace CultivoPina.Test
{
    [TestClass]
    public class CultivoPinaTest
    {
        
        [TestMethod]
        public void ProyecciondeCultivos()
        {
            var data = this.CultivosFalsos();
            Mock<ICultivo> mockRepo = new Mock<ICultivo>();

            var allItems = new List<CultivoProductivoViewModel>();
            allItems.Add(new CultivoProductivoViewModel() { PinaName = "A", SectorName = "Sector1", Mes="Febrero", TotalCultivos = 7 });
            mockRepo.Setup(ur => ur.GetAllAsyncDate()).Returns(data);
            mockRepo.Setup(ur => ur.GetProyeccionCultivos(data)).Returns(allItems);
            var controller = new CultivoController(mockRepo.Object);
            var actionResult = (ViewResult)controller.Proyeccióndecultivos();
            var itemModel = (IEnumerable<CultivoProductivoViewModel>)actionResult.Model;

            Assert.AreEqual(itemModel, allItems);
            Assert.AreEqual(1, itemModel.Count());
            Assert.IsNotNull(itemModel);


        }

        [TestMethod]
        public void CultivosProductivos()
        {

            var data = this.CultivosFalsos();
            Mock<ICultivo> mockRepo = new Mock<ICultivo>();

            var allItems = new List<CultivoProductivoViewModel>();
            allItems.Add(new CultivoProductivoViewModel() {PinaName = "PinaA", Total = 45.34, TotalCultivos = 17 });
            allItems.Add(new CultivoProductivoViewModel() { PinaName = "PinaC", Total = 13, TotalCultivos = 2 });
            allItems.Add(new CultivoProductivoViewModel() { PinaName = "PinaD", Total = 1.25, TotalCultivos = 1 });


            mockRepo.Setup(ur => ur.GetAllAsyncDate()).Returns(data);
            mockRepo.Setup(ur => ur.GetCultivoProductivo(data)).Returns(allItems);
            var controller = new CultivoController(mockRepo.Object);
            var actionResult = (ViewResult)controller.GetCultivoProductivos();
            var itemModel = (IEnumerable<CultivoProductivoViewModel>)actionResult.Model;


            Assert.AreEqual(3, itemModel.Count());
            Assert.IsNotNull(itemModel);
            Assert.AreEqual(itemModel, allItems);
        }

        [TestMethod]
        public void SectoresProductivos()
        {

            var data = this.CultivosFalsos();
            Mock<ICultivo> mockRepo = new Mock<ICultivo>();

            var allItems = new List<SectorProductivoViewModel>();
            allItems.Add(new SectorProductivoViewModel() { SectorName = "Sector1", Total = 42.51, TotalCultivos = 17 });
            allItems.Add(new SectorProductivoViewModel() { SectorName = "Sector2", Total = 4, TotalCultivos = 2 });
            allItems.Add(new SectorProductivoViewModel() { SectorName = "Sector3", Total = 2, TotalCultivos = 1 });
           
            mockRepo.Setup(ur => ur.GetAllAsyncDate()).Returns(data);
            mockRepo.Setup(ur => ur.GetSectoresProductivos(data)).Returns(allItems);
            var controller = new CultivoController(mockRepo.Object);
            var actionResult = (ViewResult)controller.GetSectoresProductivos();
            var itemModel = (IEnumerable<SectorProductivoViewModel>)actionResult.Model;


            Assert.AreEqual(3, itemModel.Count());
            Assert.AreEqual(itemModel, allItems);
            Assert.IsNotNull(itemModel);
        }

        public List<Cultivo> CultivosFalsos()
        {

            List<Cultivo> cultivos = new List<Cultivo>();

            cultivos.Add(new Cultivo() { CultivoId = 1, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 2, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 3, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 4, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 5, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 6, CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 7,  CultivoFechaRecoleccion = DateTime.Now.AddDays(-5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 8,  CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 3, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 9,  CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 2, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 10, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 3, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 11, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 3, CultivoHectareas = 100, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 12, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 105, CultivoPeso = 20 });
            cultivos.Add(new Cultivo() { CultivoId = 13, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 106, CultivoPeso = 30 });
            cultivos.Add(new Cultivo() { CultivoId = 14, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 50 });
            cultivos.Add(new Cultivo() { CultivoId = 15, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 60 });
            cultivos.Add(new Cultivo() { CultivoId = 16, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 4, CultivoHectareas = 100, CultivoPeso = 50 });
            cultivos.Add(new Cultivo() { CultivoId = 17, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 50 });
            cultivos.Add(new Cultivo() { CultivoId = 18, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 27 });
            cultivos.Add(new Cultivo() { CultivoId = 19, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 1, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 25 });
            cultivos.Add(new Cultivo() { CultivoId = 20, CultivoFechaRecoleccion = DateTime.Now.AddDays(5), CultivoFechaSiembra = DateTime.Now, SectorId = 3, PinaId = 1, CultivoHectareas = 100, CultivoPeso = 20 });


            return cultivos;
        }




    }
}