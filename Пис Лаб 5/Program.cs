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

            // Вывод всех чётных id из бд
            Console.WriteLine("Выбрать из БД те сущности, у которых идентификатор является четным:\n");
            List<Product> products = service.GetProductsWithEvenId(2);
            Console.WriteLine("{0,2}|{1,10}|{2,10}|{3,7}|", "Id", "Name", "Country", "Coust");
            Console.WriteLine("--+----------+----------+-------+");
            foreach (Product product in products)
            {
                Console.WriteLine("{0,2}|{1,10}|{2,10}|{3,7}|", product.id, product.name, product.country, product.coust);
            }
            Console.WriteLine("---------------------------------\n");


            // Вывод всех повторений name из бд
            Console.WriteLine("\nВывести все сущности с повторяющимися именами:\n");
            products = service.GetProductsWithSameName();
            Console.WriteLine("{0,2}|{1,10}|{2,10}|{3,7}|", "Id", "Name", "Country", "Coust");
            Console.WriteLine("--+----------+----------+-------+");
            foreach (Product product in products)
            {
                Console.WriteLine("{0,2}|{1,10}|{2,10}|{3,7}|", product.id, product.name, product.country, product.coust);
            }
            Console.WriteLine("---------------------------------\n");

            Console.ReadLine();
        }
    }
}
