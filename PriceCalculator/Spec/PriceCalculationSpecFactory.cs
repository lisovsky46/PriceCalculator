namespace PriceCalculator
{
    public static class PriceCalculationSpecFactory 
    {
        private const decimal TAX_PERCENT = 0.07m;
        private const decimal MARGIN_PERCENT = 0.11m;
        private const decimal EXTRA_MARGIN_PERCENT = 0.05m;

        public static PriceCalculationSpec Build(bool useExtraMargin)
        {
            var marginEffective = useExtraMargin ? MARGIN_PERCENT + EXTRA_MARGIN_PERCENT : MARGIN_PERCENT;
            return new PriceCalculationSpec(TAX_PERCENT, marginEffective);
        }


    }
}
