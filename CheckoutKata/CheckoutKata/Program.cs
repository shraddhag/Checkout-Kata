using CheckoutKata.Observers;

namespace CheckoutKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Basket basket = new Basket();
            BasketTotalObserver totalCalculator = new BasketTotalObserver(basket);
            BasketPromotionObserver promotionCalculator = new BasketPromotionObserver(basket);

            var itemA = new Item { SKU = "A", UnitPrice = 10, Quantity = 1, Discount = DiscountType.None };
            basket.AddItem(itemA);
            basket.AddItem(new Item { SKU = "B", UnitPrice = 15, Quantity = 3, Discount = DiscountType.MultiBuyCash });
            basket.AddItem(new Item { SKU = "C", UnitPrice = 40, Quantity = 1, Discount = DiscountType.None });
            basket.AddItem(new Item { SKU = "D", UnitPrice = 55, Quantity = 2, Discount = DiscountType.MultiBuyPercentage });

            var totalAmountToPay = totalCalculator.BasketTotalAmount - promotionCalculator.BasketPromotionAmount;

            System.Console.WriteLine("-------------------------------------"); 
            System.Console.WriteLine("Total amount before promotion: " + totalCalculator.BasketTotalAmount.ToString());
            System.Console.WriteLine("Total promotion amount: " + promotionCalculator.BasketPromotionAmount.ToString());

            System.Console.WriteLine("-------------------------------------");
            System.Console.WriteLine("Total amount to pay: " + totalAmountToPay.ToString());
            System.Console.WriteLine("-------------------------------------");

            System.Console.ReadKey();

        }
    }
}
