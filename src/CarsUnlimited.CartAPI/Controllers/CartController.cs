using CarsUnlimited.CartAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using CarsUnlimited.CartShared.Entities;
using RabbitMQ.Client;
using CarsUnlimited.CartAPI.Configuration;

namespace CarsUnlimited.CartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IUpdateCartService _cartService;
        private readonly ILogger<CartController> _logger;
        private readonly IConfiguration _config;
        private readonly IGetCartItems _getCartItems;

        public CartController(IUpdateCartService cartService, ILogger<CartController> logger, IConfiguration configuration, IGetCartItems getCartItems)
        {
            _cartService = cartService;
            _logger = logger;
            _config = configuration;
            _getCartItems = getCartItems;
        }

        [HttpPost]
        [Route("add-to-cart")]
        public IActionResult AddItemToCart([FromHeader(Name = "X-CarsUnlimited-SessionId")] string sessionId, [FromBody]CartItem cartItem) 
        {

            if (!string.IsNullOrWhiteSpace(sessionId))
            {
                _logger.LogInformation($"Adding item to cart {sessionId}");

                cartItem.SessionId = sessionId;

                bool addToCartResult = _cartService.AddToCart(cartItem).Result;

                if(addToCartResult)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            } else
            {
                return StatusCode(404);
            }
        }

        [HttpGet]
        [Route("get-cart-items")]
        public async Task<IActionResult> GetItemsInCart([FromHeader(Name = "X-CarsUnlimited-SessionId")] string sessionId)
        {
            if(!string.IsNullOrWhiteSpace(sessionId))
            {
                Cart cart = new Cart
                {
                    Items = await _getCartItems.GetItemsInCart(sessionId)
                };
                return StatusCode(200, cart);
            } else
            {
                return StatusCode(404);
            }
        }

        [HttpGet]
        [Route("get-cart-items-count")]
        public async Task<IActionResult> GetItemsInCartCount([FromHeader(Name = "X-CarsUnlimited-SessionId")] string sessionId)
        {
            if (!string.IsNullOrWhiteSpace(sessionId))
            {
                return StatusCode(200, await _getCartItems.GetItemsInCartCount(sessionId));
            }
            else
            {
                return StatusCode(404);
            }
        }

        [HttpGet]
        [Route("delete-item-from-cart")]
        public async Task<IActionResult> DeleteItemFromCart([FromHeader(Name = "X-CarsUnlimited-SessionId")] string sessionId, string id)
        {
            if(!string.IsNullOrWhiteSpace(sessionId) && !string.IsNullOrWhiteSpace(id))
            {
                return StatusCode(200, await _cartService.DeleteFromCart(sessionId, id));
            }

            return StatusCode(404);
        }

        [HttpGet]
        [Route("delete-cart")]
        public async Task<IActionResult> DeleteCart([FromHeader(Name = "X-CarsUnlimited-SessionId")] string sessionId)
        {
            if (!string.IsNullOrWhiteSpace(sessionId))
            {
                if (await _cartService.DeleteAllFromCart(sessionId))
                {
                    return StatusCode(200);
                }

                return StatusCode(404);
            }

            return StatusCode(404);
        }

        [HttpPost]
        [Route("complete-cart")]
        public async Task<IActionResult> CompleteCart([FromHeader(Name = "X-CarsUnlimited-SessionId")]string sessionId)
        {
            var serviceBusConfig = _config.GetSection("ServiceBusConfiguration").Get<ServiceBusConfiguration>();
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = serviceBusConfig.HostName,
                UserName = serviceBusConfig.UserName,
                Password = serviceBusConfig.Password
            };
            await _cartService.CompleteCart(sessionId, connectionFactory);
            return StatusCode(200);        
        }
    }
}
