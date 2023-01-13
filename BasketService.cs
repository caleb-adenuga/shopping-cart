
using System;
using Checkout.Data;

namespace Service
{
    public interface IBasketService
    {
        Basket GetBasket(long id);
        Basket InsertBasket(Basket basket);
        void DoStuff();
    }

    public class BasketService : IBasketService
    {
        private readonly IBasketRepository basketrepository;
        public BasketService(IBasketRepository basketrepository)
        {
            this.basketrepository = basketrepository;
        }

        public void DoStuff()
        {
            throw new NotImplementedException();
        }

        
        public Basket GetBasket(long id)
        {
            if(id <= 0)
                return new Basket();

            var mybasket = basketrepository.GetBasket(id);
            return mybasket;
        }

        public Basket InsertBasket(Basket basket)
        {
            basketrepository.CreateBasket(basket.Email);
            return new Basket();
        }
    }
}