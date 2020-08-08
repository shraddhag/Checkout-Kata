using System.Linq;
using System.Collections.Generic;

namespace CheckoutKata
{
    public class Basket
    {
        List<Item> _items = null;

        public Basket()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (item != null && !string.IsNullOrEmpty(item.SKU))
            {
                var itemToAdd = _items.SingleOrDefault(x => x.SKU == item.SKU);
                if (itemToAdd != null)
                    itemToAdd.Quantity += item.Quantity;
                else
                    _items.Add(item);                
            }
        }

        public List<Item> GetAllItems()
        {
            return _items;
        }

    }
}
