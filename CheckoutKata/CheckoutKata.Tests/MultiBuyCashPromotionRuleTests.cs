using CheckoutKata.PromotionRules.MultiBuyPromotionRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class MultiBuyCashPromotionRuleTests
    {
        decimal totalPromotion = 0m;

        [TestMethod]
        public void CalculateMultiBuyCashPromotion_WithZeroPromotionItemQuantity()
        {
            //Arrange            
            var itemB = new Item { SKU = "B", UnitPrice = 15, Quantity = 1, Discount = DiscountType.MultiBuyCash };
            MultiBuyCashPromotionRule cashPromotionRule = new MultiBuyCashPromotionRule("B", 0, 40.00m);

            //Act
            totalPromotion = cashPromotionRule.CalculateMultiBuyItemPromotion(itemB);

            //Assert
            Assert.AreEqual(0.00m, totalPromotion);
        }

        [TestMethod]
        public void CalculateMultiBuyCashPromotion_With1Items()
        {
            //Arrange            
            var itemB = new Item { SKU = "B", UnitPrice = 15, Quantity = 1, Discount = DiscountType.MultiBuyCash };
            MultiBuyCashPromotionRule cashPromotionRule = new MultiBuyCashPromotionRule("B", 3, 40.00m);

            //Act
            totalPromotion = cashPromotionRule.CalculateMultiBuyItemPromotion(itemB);

            //Assert
            Assert.AreEqual(0.00m, totalPromotion);
        }

        [TestMethod]
        public void CalculateMultiBuyCashPromotion_With3Items()
        {
            //Arrange            
            var itemB = new Item { SKU = "B", UnitPrice = 15, Quantity = 3, Discount = DiscountType.MultiBuyCash };
            MultiBuyCashPromotionRule cashPromotionRule = new MultiBuyCashPromotionRule("B", 3, 40.00m);

            //Act
            totalPromotion = cashPromotionRule.CalculateMultiBuyItemPromotion(itemB);

            //Assert
            Assert.AreEqual(5.00m, totalPromotion);
        }

        [TestMethod]
        public void CalculateMultiBuyCashPromotion_With7Items()
        {
            //Arrange
            var itemB = new Item { SKU = "B", UnitPrice = 15, Quantity = 7, Discount = DiscountType.MultiBuyCash };

            MultiBuyCashPromotionRule cashPromotionRule = new MultiBuyCashPromotionRule("B", 3, 40.00m);

            //Act
            totalPromotion = cashPromotionRule.CalculateMultiBuyItemPromotion(itemB);

            //Assert
            Assert.AreEqual(10.00m, totalPromotion);
        }
    }
}

