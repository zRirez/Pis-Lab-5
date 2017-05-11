using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository
    {
        Product GetEntity(long id);
        List<Product> GetProducts();
        void EditProduct(Product updatedEntity);
        void RemoveProduct(Product updatedEntity);
    }
}
