using System;
using System.Linq;

namespace CheckoutKata.Observers
{
    public class BasketTotalObserver
    {
        private Basket basket;

        public decimal BasketTotalAmount { get; set; }

        public BasketTotalObserver(Basket basket)
        {
            this.basket = basket;

            basket.ItemAdded += GetBasketTotal;
        }

        public void GetBasketTotal(object sender, EventArgs e)
        {
            decimal basketTotalAmount = 0.00m;

            if (sender != null)
            {
                basketTotalAmount = CalculateBasketTotal();

                BasketTotalAmount = basketTotalAmount;
                System.Console.WriteLine("Total : " + basketTotalAmount.ToString());
            }
        }

        public decimal CalculateBasketTotal()
        {
            decimal basketAmount = 0m;
            var items = basket.GetAllItems();

            if (items != null && items.Any())
            {
                foreach (var item in items)
                {
                    basketAmount += item.UnitPrice * item.Quantity;
                }
            }

            return basketAmount;
        }
    }
}
