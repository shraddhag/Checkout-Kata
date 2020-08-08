using System;
using System.Linq;
using System.Collections.Generic;

namespace CheckoutKata
{
    public class Basket
    {
        List<Item> _items = null;

        public event EventHandler ItemAdded;
        public event EventHandler ItemRemoved;

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

                OnItemAdded(EventArgs.Empty);
            }
        }

        public List<Item> GetAllItems()
        {
            return _items;
        }

        protected virtual void OnItemAdded(EventArgs e)
        {
            ItemAdded?.Invoke(this, e);
        }

        protected virtual void OnItemRemoved(EventArgs e)
        {
            ItemRemoved?.Invoke(this, e);
        }
    }
}
