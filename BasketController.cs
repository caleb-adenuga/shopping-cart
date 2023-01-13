using Microsoft.AspNetCore.Mvc;
using Service;
using System;

namespace CalebAPI.Controllers 
{

    [ApiController]
    [Route("[controller]")]
    
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketService basketService;

        public BasketController(ILogger<BasketController> logger, IBasketService basketService)
        {
            _logger = logger;
            this.basketService = basketService;
        }

        [HttpGet]
        [Route("id/{id}")]
        public IActionResult Get(int id)
        {

          var mybasket =  this.basketService.GetBasket(id);
            return Ok(mybasket);
        }

        [HttpPost]
        [Route("id/{id}")]
        public IActionResult Insert(int id)
        {
            return Ok(id);
        }



    }

    
}
