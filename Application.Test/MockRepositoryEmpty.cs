using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test
{
    class MockRepositoryEmpty : IRepository
    {
        public void EditProduct(Product updatedEntity) { }

        public Product GetEntity(long id)
        {
            return new Product { id = 1, name = "Phone", country = "China", coust = 64.5 };
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product> { };
            return products;
        }

        public void RemoveProduct(Product updatedEntity) { }
    }
}
