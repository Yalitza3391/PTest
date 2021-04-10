using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Web.Mvc;
using CultivaPina.EntityFramework.Models;
using CultivaPiñaWeb.Controllers;
using CultivoPina.Core.Cultivo;
using CultivoPina.Core.Sector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CultivoPina.Core.Pina;
using CultivaPiñaWeb.ViewModel;

namespace CultivoPina.Test.Test
{

    public class MockStores
    {
        public static Mock<ISector> MockSectorManager()
        {


            var repository = new Mock<ISector>();
       

            var allItems = new List<Sector>();

            repository.Setup(x => x.Edit(It.IsAny<Sector>()))
                .Callback((Sector i) =>
                {
                    allItems.Add(i);
                });


            // void Delete(Item t);
            repository.Setup(x => x.DeleteAsync(It.IsAny<int>()));
               

            return repository;

        }

        public static Mock<IPina> MockPinaManager()
        {
            var repository = new Mock<IPina>();
            PinaController controller = new PinaController(repository.Object);

            var allItems = new List<Pina>();

            // void CreateItem(Item t);
            repository.Setup(x => x.CreateAsync(It.IsAny<Pina>()))
                        .Callback((Pina i) =>
                        {
                            allItems.Add(i);
                        });



            // void UpdateItem(Item t);
            repository.Setup(x => x.Edit(It.IsAny<Pina>()))
                .Callback((Pina i) =>
                {
                    allItems.Add(i);
                });

            repository.Setup(x => x.DeleteAsync(It.IsAny<int>()));

          
            return repository;

        }

        public static Mock<ICultivo> MockCultivoManager()
        {

         
            var repository = new Mock<ICultivo>();
          






              


           repository.Setup(x => x.DeleteAsync(It.IsAny<int>()));
               

            return repository;

        }
    }
}
