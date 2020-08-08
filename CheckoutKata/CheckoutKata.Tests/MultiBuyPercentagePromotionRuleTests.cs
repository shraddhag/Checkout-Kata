
using CheckoutKata.PromotionRules.MultiBuyPromotionRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class MultiBuyPercentagePromotionRuleTests
    {
        decimal totalPromotion = 0m;

        [TestMethod]
        public void CalculateMultiBuyPercentagePromotion_WithZeroPromotionItemQuantity()
        {
            //Arrange
            var itemB = new Item { SKU = "D", UnitPrice = 55, Quantity = 1, Discount = DiscountType.MultiBuyPercentage };
            MultiBuyPercentagePromotionRule percentagePromotionRule = new MultiBuyPercentagePromotionRule("D", 0, 0.25m); // 25%

            //Act
            totalPromotion = percentagePromotionRule.CalculateMultiBuyItemPromotion(itemB);

            //Assert
            Assert.AreEqual(0.00m, totalPromotion);
        }

        [TestMethod]
        public void CalculateMultiBuyPercentagePromotion_With1Items()
        {
            //Arrange
            var itemB = new Item { SKU = "D", UnitPrice = 55, Quantity = 1, Discount = DiscountType.MultiBuyPercentage };
            MultiBuyPercentagePromotionRule percentagePromotionRule = new MultiBuyPercentagePromotionRule("D", 2, 0.25m);

            //Act
            totalPromotion = percentagePromotionRule.CalculateMultiBuyItemPromotion(itemB);

            //Assert
            Assert.AreEqual(0.00m, totalPromotion);
        }

        [TestMethod]
        public void CalculateMultiBuyPercentagePromotion_With2Items()
        {
            //Arrange
            var itemB = new Item { SKU = "D", UnitPrice = 55, Quantity = 2, Discount = DiscountType.MultiBuyPercentage };
            MultiBuyPercentagePromotionRule percentagePromotionRule = new MultiBuyPercentagePromotionRule("D", 2, 0.25m);

            //Act
            totalPromotion = percentagePromotionRule.CalculateMultiBuyItemPromotion(itemB);

            //Assert
            Assert.AreEqual(27.50m, totalPromotion);
        }

        [TestMethod]
        public void CalculateMultiBuyPercentagePromotion_With7Items()
        {
            //Arrange
            var itemB = new Item { SKU = "D", UnitPrice = 55, Quantity = 7, Discount = DiscountType.MultiBuyPercentage };
            MultiBuyPercentagePromotionRule percentagePromotionRule = new MultiBuyPercentagePromotionRule("D", 2, 0.25m);

            //Act
            totalPromotion = percentagePromotionRule.CalculateMultiBuyItemPromotion(itemB);

            //Assert
            Assert.AreEqual(82.50m, totalPromotion);
        }

    }
}
