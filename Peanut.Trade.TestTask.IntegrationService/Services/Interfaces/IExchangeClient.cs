using Peanut.Trade.TestTask.IntegrationService.Models;

namespace Peanut.Trade.TestTask.IntegrationService.Services.Interfaces
{
    public interface IExchangeClient
    {
        /// <summary>
        /// Get currency price from last trade
        /// </summary>
        /// <param name="inputCurrency">Input currency</param>
        /// <param name="outputCurrency">Output currency</param>
        /// <returns>Returns CurrencyLastPrice that contains last price and name of exchange where it was</returns>
        Task<CurrencyLastPrice> GetCurrencyLastPriceAsync(string inputCurrency, string outputCurrency);
    }
}
