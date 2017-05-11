using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Collections.Generic;

namespace Application.Test
{
    [TestClass]
    public class ApplicationServiceTest
    {
        IRepository mockRepository;
        IApplicationService service;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository();
            service = new ApplicationService(mockRepository);
        }


        [TestMethod]
        public void GetProductsWithEvenId_ParityOfDivider_Test()
        {
            List<long> expectedId = new List<long> { 2, 4, 6, 8 };

            List<Product> actual = service.GetProductsWithEvenId(2);
            List<long> actualId = new List<long>();
            foreach (Product item in actual)
                actualId.Add(item.id);

            CollectionAssert.AreEqual(expectedId, actualId);
        }


        [TestMethod]
        public void GetProductsWithEvenId_CorrectnessOfData_Test()
        {
            List<Product> expected = new List<Product>
            {
               new Product {id = 2, name = "Laptop", country= "USA", coust=2300.5 },
               new Product {id = 4, name = "Tablet", country= "Ukraine", coust=999.9 },
               new Product {id = 6, name = "Mic", country= "Canada", coust=404.4 },
               new Product {id = 8, name = "Headphones", country= "Sweden", coust=15 },
            };

            List<Product> actual = service.GetProductsWithEvenId(2);

            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }


        [TestMethod]
        public void GetProductsWithEvenId_NumberOfCheckedItems_Test()
        {
            int expected = 4;

            List<Product> actualList = service.GetProductsWithEvenId(2);

            Assert.AreEqual(expected, actualList.Count);
        }


        [TestMethod]
        public void GetProductsWithSameName_RepetitionDataItems_Test()
        {
            List<Product> expected = new List<Product>
            {
               new Product {id = 3, name = "Mic", country= "China", coust=78 },
               new Product {id = 6, name = "Mic", country= "Canada", coust=404.4 },
               new Product {id = 7, name = "Watches", country= "Mexico", coust=632 },
               new Product {id = 9, name = "Watches", country= "Sweden", coust=888 }
            };

            List<Product> actual = service.GetProductsWithSameName();

            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }


        [TestMethod]
        public void GetProductsWithSameName_EmptyRepetitionDataItems_Test()
        {
            mockRepository = new MockRepositoryEmpty();
            service = new ApplicationService(mockRepository);
            List<Product> expected = new List<Product> { };

            List<Product> actual = service.GetProductsWithSameName();

            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }


        [TestMethod]
        public void GetProductsWithSameName_NumberRepetitionItems_Test()
        {
            int expected = 4;

            List<Product> actualList = service.GetProductsWithSameName();

            Assert.AreEqual(expected, actualList.Count);
        }

    }
}
