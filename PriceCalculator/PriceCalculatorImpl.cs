namespace PriceCalculator
{
    public class PriceCalculatorImpl
    {
        private readonly PriceCalculationSpec priceSpec;

        public PriceCalculatorImpl(PriceCalculationSpec priceSpec)
        {
            this.priceSpec = priceSpec;
        }

        public decimal CalculateTaxedItemPrice(decimal startPrice, bool exempt)
        {
            if (startPrice < 0) throw new ArgumentOutOfRangeException(nameof(startPrice));

            var taxedResult = exempt ? startPrice : startPrice * (1 + priceSpec.TaxPercent);
            var roundedResult = decimal.Round(taxedResult, 2, MidpointRounding.AwayFromZero);

            return roundedResult;
        }

        public decimal CalculateTotal(decimal startPriceTotal, decimal taxedPriceTotal)
        {
            if (startPriceTotal < 0) throw new ArgumentOutOfRangeException(nameof(startPriceTotal));
            if (taxedPriceTotal < 0) throw new ArgumentOutOfRangeException(nameof(taxedPriceTotal));

            var marginTotal = startPriceTotal * priceSpec.MarginPercent;
            var resultTotal = taxedPriceTotal + marginTotal;
            var roundedResult = RoundTotal(resultTotal);

            return roundedResult;
        }

        private decimal RoundTotal(decimal value)
        {
            var result = decimal.Round(value, 2, MidpointRounding.ToZero);
            var isOdd = (result * 100) % 2 == 1;
            if (isOdd)
                result += 0.01m;
            return result;
        }
    }
}
