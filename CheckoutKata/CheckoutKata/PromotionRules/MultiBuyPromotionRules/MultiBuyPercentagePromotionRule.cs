
namespace CheckoutKata.PromotionRules.MultiBuyPromotionRules
{
    public class MultiBuyPercentagePromotionRule : IMultiBuyPromotionRule
    {
        public string SKU { get; set; }
        public int PromotionItemQuantity { get; set; }
        public decimal PromotionPercentage { get; set; }

        public MultiBuyPercentagePromotionRule(string sku, int promotionItemQuantity, decimal promotionPercentage)
        {
            SKU = sku;
            PromotionItemQuantity = promotionItemQuantity;
            PromotionPercentage = promotionPercentage;
        }

        public decimal CalculateMultiBuyItemPromotion(Item item)
        {
            decimal totalPromotion = 0m;

            if (item.Discount == DiscountType.MultiBuyPercentage)
            {
                if (item.SKU == SKU)
                {
                    if (PromotionItemQuantity > 0 && item.Quantity >= PromotionItemQuantity)
                    {
                        var discountedItemQuantity = item.Quantity - (item.Quantity % PromotionItemQuantity);
                        totalPromotion = (item.UnitPrice * discountedItemQuantity) * PromotionPercentage;
                    }
                }
            }

            return totalPromotion;
        }
    }
}
