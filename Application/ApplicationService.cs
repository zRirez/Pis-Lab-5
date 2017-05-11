using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    public class ApplicationService : IApplicationService
    {

        private readonly IRepository repository;

        public ApplicationService(IRepository repository)
        {
            this.repository = repository;
        }


        public List<Product> GetProductsWithEvenId(int divider)
        {
            List<Product> products = repository.GetProducts();

            products.RemoveAll(x => x.id % divider != 0);

            return products;
        }


        public List<Product> GetProductsWithSameName()
        {
            List<Product> products = repository.GetProducts();
            List<Product> products2 = new List<Product>();

            var group = products.GroupBy(x => x.name).Where(g => g.Count() > 1);
            products = new List<Product>();

            foreach (IGrouping<string, Product> gr in group)
            {
                foreach (var item in gr)
                {
                    products.Add(item);
                }
            }
            return products;
        }
    }
}
