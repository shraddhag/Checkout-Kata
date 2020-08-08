using CheckoutKata.PromotionRules.MultiBuyPromotionRules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Observers
{
    public class BasketPromotionObserver
    {
        private Basket basket;
        List<IMultiBuyPromotionRule> _multiBuyPromotionRules = new List<IMultiBuyPromotionRule>();

        public decimal BasketPromotionAmount { get; set; }

        public BasketPromotionObserver(Basket basket)
        {
            this.basket = basket;

            //load multi-buy promotion rules
            _multiBuyPromotionRules.Add(new MultiBuyCashPromotionRule("B", 3, 40.00m));
            _multiBuyPromotionRules.Add(new MultiBuyPercentagePromotionRule("D", 2, 0.25m));

            basket.ItemAdded += GetBasketPromotion;
        }

        public void GetBasketPromotion(object sender, EventArgs e)
        {
            decimal basketTotalPromotionAmount = 0m;

            if (sender != null)
            {
                basketTotalPromotionAmount = CalculateBasketPromotion();

                BasketPromotionAmount = basketTotalPromotionAmount;
                System.Console.WriteLine("Promotion : " + basketTotalPromotionAmount.ToString());
            }
        }

        public decimal CalculateBasketPromotion()
        {
            decimal basketPromotionAmount = 0m;
            var items = basket.GetAllItems();

            if (items != null && items.Any())
            {
                foreach (var item in items)
                {
                    basketPromotionAmount += CalculateItemPromotion(item);
                }
            }

            return basketPromotionAmount;
        }

        private decimal CalculateItemPromotion(Item item)
        {
            decimal itemPromotionAmount = 0.00m;

            foreach (var rule in _multiBuyPromotionRules)
            {
                itemPromotionAmount += rule.CalculateMultiBuyItemPromotion(item);
            }

            return itemPromotionAmount;
        }
    }
}
