
namespace CheckoutKata
{
    public class Item
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DiscountType Discount { get; set; }
    }

    public enum DiscountType
    {
        None,
        MultiBuyCash,
        MultiBuyPercentage
    }
}
