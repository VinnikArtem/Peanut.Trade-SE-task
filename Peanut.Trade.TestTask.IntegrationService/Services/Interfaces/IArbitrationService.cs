using Peanut.Trade.TestTask.IntegrationService.Models;

namespace Peanut.Trade.TestTask.IntegrationService.Services.Interfaces
{
    public interface IArbitrationService
    {
        /// <summary>
        /// Get best estimated offer for input currency
        /// </summary>
        /// <param name="inputAmount">Input amount of currency</param>
        /// <param name="inputCurrency">Input currency</param>
        /// <param name="outputCurrency">Output currency</param>
        /// <returns>Best estimated offer</returns>
        Task<BestEstimatedOffer> GetBestEstimatedOfferAsync(decimal inputAmount, string inputCurrency, string outputCurrency);
    }
}
