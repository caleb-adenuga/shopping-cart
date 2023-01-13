using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using Dapper;


namespace Checkout.Data
{
    public interface IBasketRepository
    {
  
        Basket GetBasket(long id);
        Basket InsertBasket(string UserEmail, int TotalPrice);
        void CallMyMethod(string v);
        void CreateBasket(object email);
    }

    public class assignto
    {
        internal static long Id;
        internal static string UserEmail;
        internal static double TotalPrice;
    }

    public class BasketRepository : IBasketRepository
    {
        SqlConnection _sql;

        public BasketRepository(string connectionString)
        {
            _sql = new SqlConnection(connectionString);

        }

        public Basket InsertBasket(string UserEmail, int TotalPrice)
        {
            const string sqlPut =
                        @"INSERT INTO Basket (UserEmail, TotalPrice)
              OUTPUT INSERTED.Id 
              Values (@UserEmail, @TotalPrice)";
            _sql.Query(sqlPut, new { UserEmail = UserEmail, TotalPrice = TotalPrice.ToString() });

            throw new NotImplementedException();

        }
        public Basket GetBasket(long id)

        {
            const string sqlGet = "SELECT * FROM Basket WHERE Id = @Id"; //selecting a basket from a specific id
            _sql.Query(sqlGet, new { Id = id.ToString() });


            return new Basket()
            {
                Id = assignto.Id,
                Email = assignto.UserEmail,
                Price = assignto.TotalPrice
            };
        }

        public void CallMyMethod(string v)
        {
            throw new NotImplementedException();
        }

        public void CreateBasket(object email)
        {
            throw new NotImplementedException();
        }


        // inserting into the basket the users email and total price of basket
        //the values inserted are the user email and total price

        public long Id { get; set; }
        public string Email { get; set; }
        public decimal Price { get; set; }

        public List<BasketItem> Items { get; set; }
    }
}





