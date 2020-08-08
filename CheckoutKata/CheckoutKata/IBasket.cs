using System.Collections.Generic;

namespace CheckoutKata
{
    public interface IBasket
    {
        void AddItem(Item item);        
        List<Item> GetAllItems();
    }
}
