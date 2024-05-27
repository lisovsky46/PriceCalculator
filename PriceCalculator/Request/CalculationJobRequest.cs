namespace PriceCalculator
{
    public class CalculationJobRequest
    {
        public bool ExtraMargin { get; set; }

        public IEnumerable<CalculationJobItem> Items { get; set; } = new CalculationJobItem[0];

        public CalculationJobRequest()
        {
            
        }
    }
}
