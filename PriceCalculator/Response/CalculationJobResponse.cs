namespace PriceCalculator
{
    public class CalculationJobResponse
    {
        public CalculationJobItemResult[] Items { get; set; } = new CalculationJobItemResult[0];

        public CalculationJobResponse()
        {
            
        }

        public CalculationJobResponse(CalculationJobItemResult[] resultItems)
        {
            Items = resultItems;
        }
    }
}
