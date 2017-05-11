using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NLog;

namespace Application
{
    public class ApplicationService : IApplicationService
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IRepository repository;

        public ApplicationService(IRepository repository)
        {
            logger.Trace("Enter ApplicationService " + repository);
            this.repository = repository;
            logger.Trace("Exit ApplicationService " + repository);
        }


        public List<Product> GetProductsWithEvenId(int divider)
        {
            logger.Trace("Enter GetProductsWithEvenId " + divider);
            List<Product> products = repository.GetProducts();

            products.RemoveAll(x => x.id % divider != 0);

            string log = "";
            foreach (Product i in products)
            {
                log += Environment.NewLine + "{";
                log += i.id.ToString() + " ";
                log += i.name + " ";
                log += i.country + " ";
                log += i.coust.ToString();
                log += "}";
            }
            logger.Debug(log);
            logger.Trace("Exit GetProductsWithEvenId " + products);
            return products;
        }


        public List<Product> GetProductsWithSameName()
        {
            logger.Trace("Enter GetProductsWithSameName ");
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

            string log = "";
            foreach (Product i in products)
            {
                log += Environment.NewLine + "{";
                log += i.id.ToString() + " ";
                log += i.name + " ";
                log += i.country + " ";
                log += i.coust.ToString();
                log += "}";
            }
            logger.Debug(log);
            logger.Trace("Exit GetProductsWithSameName " + products);
            return products;
        }
    }
}
