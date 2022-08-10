using CarsUnlimited.CartShared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsUnlimited.CartAPI.Services
{
    public interface IGetCartItems
    {
        Task<int> GetItemsInCartCount(string sessionId);
        Task<List<CartItem>> GetItemsInCart(string sessionId);
    }
}
