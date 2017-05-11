using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Application;
using System.Collections.Generic;

namespace Application.Test
{
    [TestClass]
    public class ApplicationServiceTest
    {

        [TestMethod]
        public void GetProductsWithEvenId_CorrectnessOfData_Test()
        {
            IRepository mockRepository = new MockRepository();
            IApplicationService service = new ApplicationService(mockRepository);

            List<Product> expected = new List<Product>
            {
               new Product {id = 2, name = "Phone", country= "USA", coust=2300.5 },
               new Product {id = 4, name = "Phone", country= "Ukraine", coust=999.9 },
               new Product {id = 6, name = "Mic", country= "Canada", coust=404.4 },
               new Product {id = 8, name = "Headphones", country= "Sweden", coust=15 }
            };
            List<long> expectedId = new List<long> { 2, 4, 6, 8 };

            List<Product> actual = service.GetProductsWithEvenId(2);

            List<long> actualId = new List<long>();
            foreach (Product i in actual)
            {
                actualId.Add(i.id);
            }

            for (int i = 0; i < expectedId.Count; ++i)
            {
                Console.WriteLine(expectedId[i] + " " + actualId[i]);
            }

            Assert.AreSame(expectedId, actualId);
        }

        [TestMethod]
        public void GetProductsWithSameName__Test()
        {

        }

    }
}
