using Microsoft.AspNetCore.Mvc;

namespace PriceCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceCalculatorController : ControllerBase
    {
        private readonly ILogger<PriceCalculatorController> _logger;

        public PriceCalculatorController(ILogger<PriceCalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "CalculatePrice")]
        public CalculationJobResponse CalculatePrice(CalculationJobRequest request)
        {
            var model = new PriceCalculatorModel(request.ExtraMargin);
            var resultItems = model.ProcessItems(request.Items);

            return new CalculationJobResponse(resultItems);
        }


    }
}
