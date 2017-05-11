using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test
{
    class MockRepository : IRepository
    {
        public void EditProduct(Product updatedEntity) { }

        public Product GetEntity(long id)
        {
            return new Product { id = 1, name = "Phone", country = "China", coust = 64.5 };
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>
            {
               new Product {id = 1, name = "Phone", country= "China", coust=64.5 },
               new Product {id = 2, name = "Phone", country= "USA", coust=2300.5 },
               new Product {id = 3, name = "Mic", country= "China", coust=78 },
               new Product {id = 4, name = "Phone", country= "Ukraine", coust=999.9 },
               new Product {id = 5, name = "TV", country= "Russia", coust=654 },
               new Product {id = 6, name = "Mic", country= "Canada", coust=404.4 },
               new Product {id = 7, name = "Watches", country= "Mexico", coust=632 },
               new Product {id = 8, name = "Headphones", country= "Sweden", coust=15 }
            };
            return products;
        }

        public void RemoveProduct(Product updatedEntity) { }
    }
}
