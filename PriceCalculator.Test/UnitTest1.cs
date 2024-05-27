namespace PriceCalculator.Test
{
    [TestFixture]
    public class Tests
    {
        private decimal envelopesPrice = 520m;
        private decimal envelopesPriceTaxed = 556.40m;
        private decimal letterheadPrice = 1983.37m;
        private decimal letterheadPriceTaxed = 1983.37m;
        private decimal envelopAndLetterheadTotal = 2940.30m;

        private decimal tshirt = 294.04m;
        private decimal tshirtTaxed = 314.62m;
        private decimal tshirtTotal = 346.96m;


        private PriceCalculatorImpl calculatorWithExtraMargin;
        private PriceCalculatorImpl calculatorWithOutExtraMargin;

        [SetUp]
        public void Setup()
        {

            var specWithExtra = PriceCalculationSpecFactory.Build(true);
            calculatorWithExtraMargin = new PriceCalculatorImpl(specWithExtra);


            var specWithoutExtra = PriceCalculationSpecFactory.Build(false);
            calculatorWithOutExtraMargin = new PriceCalculatorImpl(specWithoutExtra);

        }

        [Test]
        public void TaxEqual()
        {
            var res = calculatorWithExtraMargin.CalculateTaxedItemPrice(envelopesPrice, false);

            Assert.That(res, Is.EqualTo(envelopesPriceTaxed));
        }

        [Test]
        public void TaxExemptEqual()
        {
            var res = calculatorWithExtraMargin.CalculateTaxedItemPrice(letterheadPrice, true);

            Assert.That(res, Is.EqualTo(letterheadPriceTaxed));
        }

        [Test]
        public void TotalPriceWithExtraMarginEqual()
        {
            var res = calculatorWithExtraMargin.CalculateTotal(envelopesPrice + letterheadPrice, envelopesPriceTaxed + letterheadPriceTaxed);

            Assert.That(res, Is.EqualTo(envelopAndLetterheadTotal));
        }

        [Test]
        public void TotalPriceWithOutExtraMarginEqual()
        {
            var res = calculatorWithOutExtraMargin.CalculateTotal(tshirt, tshirtTaxed);

            Assert.That(res, Is.EqualTo(tshirtTotal));
        }

        [Test]
        public void NegativePriceItemException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => calculatorWithExtraMargin.CalculateTaxedItemPrice(-1, false));
        }


        [Test]
        public void NegativeBasePriceTotalException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => calculatorWithExtraMargin.CalculateTotal(-1, 1));
        }


        [Test]
        public void NegativeTaxedPriceTotalException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => calculatorWithExtraMargin.CalculateTotal(1, -1));
        }




    }
}