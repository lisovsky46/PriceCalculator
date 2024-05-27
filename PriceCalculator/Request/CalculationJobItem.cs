namespace PriceCalculator
{
    public class CalculationJobItem
    {
        public string ItemName { get; set; } = "";

        public decimal ItemPrice { get; set; }

        public bool Exempt { get; set; }

        public CalculationJobItem()
        {
            
        }
    }
}
