namespace PriceCalculator
{
    public class PriceCalculationSpec
    {
        public decimal TaxPercent { get; }

        public decimal MarginPercent { get; }

        public PriceCalculationSpec(decimal taxPercent, decimal marginPercent)
        {
            if (taxPercent <= 0) throw new ArgumentOutOfRangeException(nameof(taxPercent));
            if (marginPercent <= 0) throw new ArgumentOutOfRangeException(nameof(marginPercent));

            TaxPercent = taxPercent;
            MarginPercent = marginPercent;
        }
    }
}
