using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IApplicationService
    {
        List<Product> GetProductsWithEvenId(int divider);
        List<Product> GetProductsWithSameName();
    }
}
