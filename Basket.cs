using System;
using System.Data;

namespace Checkout.Data
{
    public class Basket
    {
        public long Id { get; set; }
        public string User;
        public string Email;
        public double Price;

        public void CreateBasket(string rowName)

        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
        }

        private class DynamicParameters
        {
            internal void Add(string v, DbType dbType, ParameterDirection direction)
            {
                throw new NotImplementedException();
            }
        }
    }
}