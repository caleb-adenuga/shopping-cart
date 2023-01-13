using CalebAPI.Utilities;
using Checkout.Data;
using Service;
using Xunit;
using Moq;
using System;

namespace CalebAPI.Tests
{
    public class BasketServiceTests
    {
        private Mock<IBasketRepository> _basketRepository;
        private Mock<IBasketItemsRepository> _basketItemsRepository;
        private IBasketService _BasketService;

        public Basket BasketToReturn { get; private set; }

        public BasketServiceTests()
        {
            _basketRepository = new Mock<IBasketRepository>();
            _basketItemsRepository = new Mock<IBasketItemsRepository>();

            _BasketService = new BasketService(_basketRepository.Object);
            BasketToReturn = new Basket
            {
                Id = 1,
                User = "test", 
                Email = "john@gmail.com"
                
            };
        }

        [Fact]
        public void WhenCallingGetBasket_ItCallsBasketRepositoryWithThePassedInID()
        {
            var BasketToReturn = new Basket
            {
                Id = 77
            };

            _BasketService.GetBasket(BasketToReturn.Id);
            _basketRepository.Verify(x => x.GetBasket(BasketToReturn.Id), Moq.Times.Once);
        }

        [Fact]
        public void GetBasket_ShouldNotRun_IfId_ZeroOrBelow()
        {
            const long id = 0;

            _BasketService.GetBasket(id);

            _basketRepository.Verify(s => s.GetBasket(id), Times.Never);
        }


        [Fact]
        public void CreateBasketShouldRunCreateBasket()
        {

            _BasketService.InsertBasket(BasketToReturn);
            _basketRepository.Verify(x => x.CreateBasket(BasketToReturn.Email));
        }

        [Fact]
        public void WhenRetreivingABasketThatExistsFromTheService_TheBasketIsReturned()
        {
            _basketRepository
                .Setup(service => service.GetBasket(BasketToReturn.Id))
                .Returns(BasketToReturn);

            var result = _BasketService.GetBasket(BasketToReturn.Id);

            Assert.Equal(BasketToReturn, result);
        }
    }
}

