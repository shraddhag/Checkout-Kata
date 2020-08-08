using CheckoutKata.Observers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class BasketPromotionObserverTests
    {
        Basket basket = null;
        BasketPromotionObserver basketPromotionObserver = null;

        public BasketPromotionObserverTests()
        {
            basket = new Basket();
            basketPromotionObserver = new BasketPromotionObserver(basket);
        }

        [TestMethod]
        public void CalculateBasketPromotion_WhenMultipleItemsAdded_Successful()
        {
            //Arrange
            basket.AddItem(new Item { SKU = "A", UnitPrice = 10, Quantity = 4, Discount = DiscountType.None });
            basket.AddItem(new Item { SKU = "B", UnitPrice = 15, Quantity = 7, Discount = DiscountType.MultiBuyCash });
            basket.AddItem(new Item { SKU = "C", UnitPrice = 40, Quantity = 2, Discount = DiscountType.None });
            basket.AddItem(new Item { SKU = "D", UnitPrice = 55, Quantity = 3, Discount = DiscountType.MultiBuyPercentage });

            //Act
            var basketPromotion = basketPromotionObserver.CalculateBasketPromotion();

            //Assert
            Assert.IsNotNull(basketPromotion);
            Assert.AreEqual(37.50m, basketPromotion);
        }


        [TestMethod]
        public void CalculateBasketPromotion_WhenItemAddedMultipleTimes_Successful()
        {
            //Arrange
            basket.AddItem(new Item { SKU = "B", UnitPrice = 15, Quantity = 2, Discount = DiscountType.MultiBuyCash });
            basket.AddItem(new Item { SKU = "B", UnitPrice = 15, Quantity = 2, Discount = DiscountType.MultiBuyCash });

            //Act
            var basketPromotion = basketPromotionObserver.CalculateBasketPromotion();

            //Assert
            Assert.IsNotNull(basketPromotion);
            Assert.AreEqual(5.00m, basketPromotion);
        }
    }
}
