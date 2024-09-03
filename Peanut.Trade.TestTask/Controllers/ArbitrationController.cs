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
        private readonly IValidator<RatesQueryContract> _ratesQueryContractValidator;

        public ArbitrationController(
            IArbitrationService arbitrationService,
            IValidator<EstimateQueryContract> estimateQueryContractValidator,
            IValidator<RatesQueryContract> ratesQueryContractValidator)
        {
            _arbitrationService = arbitrationService ?? throw new ArgumentNullException(nameof(arbitrationService));
            _estimateQueryContractValidator = estimateQueryContractValidator ?? throw new ArgumentNullException(nameof(estimateQueryContractValidator));
            _ratesQueryContractValidator = ratesQueryContractValidator ?? throw new ArgumentNullException(nameof(ratesQueryContractValidator));
        }

        [HttpGet("estimate")]
        public async Task<IActionResult> GetEstimate([FromQuery] EstimateQueryContract estimateQueryContract)
        {
            var validationResult = await _estimateQueryContractValidator.ValidateAsync(estimateQueryContract);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.Aggregate(string.Empty, (s, failure) => s += failure.ErrorMessage + ";");

                return BadRequest(errorMessage);
            }

            var bestEstimatedOffer = await _arbitrationService.GetBestEstimatedOfferAsync(
                estimateQueryContract.InputAmount,
                estimateQueryContract.InputCurrency,
                estimateQueryContract.OutputCurrency);

            return Ok(bestEstimatedOffer);
        }

        [HttpGet("rates")]
        public async Task<IActionResult> GetRates([FromQuery] RatesQueryContract ratesQueryContract)
        {
            var validationResult = await _ratesQueryContractValidator.ValidateAsync(ratesQueryContract);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.Aggregate(string.Empty, (s, failure) => s += failure.ErrorMessage + ";");

                return BadRequest(errorMessage);
            }

            var bestEstimatedOffer = await _arbitrationService.GetRatesAsync(
                ratesQueryContract.BaseCurrency,
                ratesQueryContract.QuoteCurrency);

            return Ok(bestEstimatedOffer);
        }
    }
}
