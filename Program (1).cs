using System;
using System.Collections.Generic;

namespace Checkout.Data.Tests
{
    class Program
    {
        static readonly string connectionstring = "Server=DESKTOP-LHSQMU9\\SQLEXPRESS01; Database=MyApp; Trusted_connection=true";
        static readonly BasketRepository basketrepository = new BasketRepository(connectionstring);
        static readonly ProductRepository productrepository = new ProductRepository(connectionstring);
        static readonly BasketItemsRepository basketitemsrepository = new BasketItemsRepository(connectionstring, productrepository);

        static void Main(string[] args)
        {

            //p.GetProducts();

            Basket basket = basketrepository.GetBasket(5);
            IEnumerable<BasketItem> items = basketitemsrepository.GetItemsForBasket(5).ToList();
            List<long> ids = new List<long>();
            foreach (BasketItem item in items)
            {
                ids.Add(item.Id);

            }
            basketitemsrepository.DeleteItemsFromBasket(basket, ids.ToArray());
        }
    }
}