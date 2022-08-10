using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsUnlimited.CartShared.Entities
{
    public class CartItem
    {
        public string SessionId { get; set; }
        public string Id { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }

    public class Cart
    {        
        public double Total { 
            get
            {
                double total = 0;
                foreach(CartItem cartItem in Items)
                {
                    total += cartItem.Price * cartItem.Count;
                }
                return total;
            }
        }
        public List<CartItem> Items { get; set; }
    }
}
