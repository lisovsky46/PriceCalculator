
using System.Diagnostics;

namespace PriceCalculator
{
    internal class PriceCalculatorModel
    {
        private const string TOTAL_NAME = "total";

        private readonly PriceCalculatorImpl priceCalculator;

        public PriceCalculatorModel(bool extraMargin)
        {
            priceCalculator = BuildCalculator(extraMargin);
        }

        private PriceCalculatorImpl BuildCalculator(bool extraMargin)
        {
            var priceSpec = PriceCalculationSpecFactory.Build(extraMargin);

            return new PriceCalculatorImpl(priceSpec);
        }

        public CalculationJobItemResult[] ProcessItems(IEnumerable<CalculationJobItem> requestItems)
        {
            List<CalculationJobItemResult> resultItems = [.. requestItems.AsParallel().Select(CalculateItem)];

            var totalItem = CalculateTotal(requestItems, resultItems);
            resultItems.Add(totalItem);

            return resultItems.ToArray();
        }

        private CalculationJobItemResult CalculateItem(CalculationJobItem jobItem)
        {
            var newPrice = priceCalculator.CalculateTaxedItemPrice(jobItem.ItemPrice, jobItem.Exempt);
            return new CalculationJobItemResult(jobItem.ItemName, newPrice);
        }

        private CalculationJobItemResult CalculateTotal(IEnumerable<CalculationJobItem> requestItems, IEnumerable<CalculationJobItemResult> calculatedItems)
        {
            var baseSum = requestItems.Sum(i => i.ItemPrice);
            var taxedSum = calculatedItems.Sum(i => i.ItemPrice);
            var totalSum = priceCalculator.CalculateTotal(baseSum, taxedSum);

            return new CalculationJobItemResult(TOTAL_NAME, totalSum);
        }
    }
}
