using StackExchange.Redis.Extensions.Core.Abstractions;
using Microsoft.Extensions.Logging;
using CarsUnlimited.CartShared.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using StackExchange.Redis;
using System.Linq;

namespace CarsUnlimited.CartAPI.Services
{
    public class GetCartItems : IGetCartItems
    {   
        private readonly IRedisCacheClient _redisCacheClient;
        private readonly ILogger<UpdateCartService> _logger;

        public GetCartItems(IRedisCacheClient redisCacheClient, ILogger<UpdateCartService> logger)
        {
            _redisCacheClient = redisCacheClient;
            _logger = logger;
        }

        public async Task<List<CartItem>> GetItemsInCart(string sessionId)
        {
            List<CartItem> cartItems = new List<CartItem>();

            try
            {
                var keys = await SearchKeys(sessionId);
                if (keys.Any()) {
                    foreach (string key in keys)
                    {
                        CartItem cartItem = await _redisCacheClient.GetDbFromConfiguration().GetAsync<CartItem>(key);
                        cartItems.Add(cartItem);
                    }
                }
            } 
            catch (RedisException ex)
            {
                _logger.LogError($"GetItemsInCart: Redis Error: {ex.Message}");
            }

            return cartItems;
        }

        public async Task<int> GetItemsInCartCount(string sessionId)
        {
            List<CartItem> cartItems = await GetItemsInCart(sessionId);
            int cartItemsCount = 0;

            foreach(CartItem cartItem in cartItems)
            {
                cartItemsCount += cartItem.Count;
            }

            return cartItemsCount;
            
        }

        internal async Task<List<string>> SearchKeys(string sessionId)
        {
            try
            {
                var keys = await _redisCacheClient.GetDbFromConfiguration().SearchKeysAsync($"*{sessionId}*");
                return keys.ToList();
            }
            catch (RedisException ex)
            {
                _logger.LogError($"SearchKeys: Redis Error: {ex.Message}");
                return null;
            }
        }
    }
}