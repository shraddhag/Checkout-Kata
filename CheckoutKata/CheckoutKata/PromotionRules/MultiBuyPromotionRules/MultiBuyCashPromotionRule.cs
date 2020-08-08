
namespace CheckoutKata.PromotionRules.MultiBuyPromotionRules
{
    public class MultiBuyCashPromotionRule
    {
        public string SKU { get; set; }
        public int PromotionItemQuantity { get; set; }
        public decimal PromotionPrice { get; set; }

        public MultiBuyCashPromotionRule(string sku, int promotionItemQuantity, decimal promotionPrice)
        {
            SKU = sku;
            PromotionItemQuantity = promotionItemQuantity;
            PromotionPrice = promotionPrice;
        }

        public decimal CalculateMultiBuyItemPromotion(Item item)
        {
            decimal totalPromotion = 0m;

            if (item.SKU == SKU && item.Discount == DiscountType.MultiBuyCash)
            {
                if (PromotionItemQuantity > 0 && item.Quantity >= PromotionItemQuantity)
                {
                    var perLotPromotion = (item.UnitPrice * PromotionItemQuantity) - PromotionPrice;
                    var totalDiscountedItemQuantity = item.Quantity - (item.Quantity % PromotionItemQuantity);

                    if (totalDiscountedItemQuantity > PromotionItemQuantity)
                    {
                        totalPromotion = perLotPromotion * (totalDiscountedItemQuantity / PromotionItemQuantity);
                    }
                    else
                    {
                        totalPromotion = perLotPromotion;
                    }
                }
            }

            return totalPromotion;
        }
    }
}
