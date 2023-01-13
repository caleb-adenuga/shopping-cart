using Checkout.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProducts();
    }

    public class ProductsService : IProductsService
    {
        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

    }

}
