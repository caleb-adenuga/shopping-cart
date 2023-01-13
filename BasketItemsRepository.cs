using System;
using System.Collections.Generic;
namespace Checkout.Data
{
    public interface IBasketItemsRepository
    {
        void DeleteItemsFromBasket(Basket basket, long[] basketids);
        IEnumerable<BasketItem> GetItemsForBasket(long v);
    }

    public class BasketItemsRepository : IBasketItemsRepository
    {
        private string connectionstring;
        private ProductRepository p;

        public BasketItemsRepository(string connectionstring)
        {
            this.connectionstring = connectionstring;
            this.p = p;
        }








        public IEnumerable<BasketItem> GetItemsForBasket(long v)
        {
            return new List<BasketItem>() {

new BasketItem() { Id = v },

        };
        }

        public void DeleteItemsFromBasket(Basket basket, long[] basketids)
        {
            throw new NotImplementedException();
        }
    }
}