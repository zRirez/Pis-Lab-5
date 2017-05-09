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

            ApplicationService service = new ApplicationService()

            List<Product> products = service.GetProductsWithEvenId(2);
        }
    }
}
