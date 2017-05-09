using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пис_Лаб_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "Data Source=ALEXANDR-NOUT-W\\SQLEXPRESS;Initial Catalog=ProductsDb;Integrated Security=True";
            IRepository repository = new Repository(address);
            IApplicationService service = new ApplicationService(repository);

            List<Product> products = service.GetProductsWithEvenId(2);

            foreach (Product product in products)
            {
                Console.WriteLine("{0} {1} {2} {3}", product.id, product.name, product.country, product.coust);
            }

            Console.ReadLine();
        }
    }
}
