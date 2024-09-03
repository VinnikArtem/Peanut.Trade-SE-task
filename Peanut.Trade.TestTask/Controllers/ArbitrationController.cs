using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Peanut.Trade.TestTask.IntegrationService.Services.Interfaces;
using Peanut.Trade.TestTask.Models;

namespace Peanut.Trade.TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArbitrationController : ControllerBase
    {
        private readonly IArbitrationService _arbitrationService;
        private readonly IValidator<EstimateQueryContract> _estimateQueryContractValidator;

        public ArbitrationController(
            IArbitrationService arbitrationService,
            IValidator<EstimateQueryContract> estimateQueryContractValidator)
        {
            _arbitrationService = arbitrationService ?? throw new ArgumentNullException(nameof(arbitrationService));
            _estimateQueryContractValidator = estimateQueryContractValidator ?? throw new ArgumentNullException(nameof(estimateQueryContractValidator));
        }

        [HttpGet("estimate")]
        public async Task<IActionResult> GetEstimate([FromQuery] EstimateQueryContract estimateQueryContract)
        {
            var validationResult = await _estimateQueryContractValidator.ValidateAsync(estimateQueryContract);

            if (!validationResult.IsValid) return BadRequest();

            var bestEstimatedOffer = await _arbitrationService.GetBestEstimatedOfferAsync(
                estimateQueryContract.InputAmount,
                estimateQueryContract.InputCurrency,
                estimateQueryContract.OutputCurrency);

            return Ok(bestEstimatedOffer);
        }
    }
}
