using System.ComponentModel.DataAnnotations;

namespace PriceCalculator
{
    public class CalculationJobRequest
    {
        [Required]
        public bool ExtraMargin { get; set; }

        [MinLength(1)]
        public IEnumerable<CalculationJobItem> Items { get; set; } = new CalculationJobItem[0];

        public CalculationJobRequest()
        {
            
        }
    }
}
