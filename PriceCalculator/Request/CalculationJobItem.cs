using System.ComponentModel.DataAnnotations;

namespace PriceCalculator
{
    public class CalculationJobItem
    {
        [Required]
        public string ItemName { get; set; } = "";

        [Required]
        public decimal ItemPrice { get; set; }

        [Required]
        public bool Exempt { get; set; }

        public CalculationJobItem()
        {
            
        }
    }
}
