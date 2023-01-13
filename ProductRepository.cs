
using Checkout.Data.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Checkout.Data
{
    public class ProductRepository
    {
        private SqlConnection _sql;

        public ProductRepository(string connectionString)
        {
            _sql = new SqlConnection(connectionString);
        }

        public Product GetProductById(int id)
        {
            const string sqlGet = "SELECT * FROM Products WHERE Id = @Id";
            return _sql.ExecuteScalar<Product>(sqlGet, new { Id = id.ToString() });
        }

        public IEnumerable<Product> GetAllProducts(int ProductTypeId)
        {
            const string sqlGet = "SELECT * FROM Products";
            return _sql.Query<Product>(sqlGet);
        }
    }
}