﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class BasketTests
    {
        Basket basket = new Basket();

        [TestMethod]
        public void AddBasketItem_Succesful()
        {
            //Arrange
            var itemA = new Item { SKU = "A", UnitPrice = 10, Quantity = 1, Discount = DiscountType.None };

            //Act
            basket.AddItem(itemA);

            //Assert
            var basketItems = basket.GetAllItems();

            Assert.IsNotNull(basketItems);
            Assert.AreEqual(1, basketItems.Count);
            Assert.AreEqual("A", basketItems[0].SKU);
        }

        [TestMethod]
        public void AddNullBasketItem_Failed()
        {
            //Arrange
            var emptyItem = new Item();

            //Act
            basket.AddItem(emptyItem);

            //Assert
            var basketItems = basket.GetAllItems();

            Assert.IsNotNull(basketItems);
            Assert.AreEqual(0, basketItems.Count);            
        }
    }
}
