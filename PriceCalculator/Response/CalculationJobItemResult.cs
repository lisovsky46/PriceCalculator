namespace PriceCalculator
{
    public class CalculationJobItemResult
    {
        public string ItemName { get; set; } = "";

        public decimal ItemPrice { get; set; }

        public CalculationJobItemResult(string itemName, decimal itemPrice)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
        }
    }
}
