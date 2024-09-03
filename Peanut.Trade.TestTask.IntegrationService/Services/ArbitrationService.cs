using Peanut.Trade.TestTask.IntegrationService.Models;
using Peanut.Trade.TestTask.IntegrationService.Services.Interfaces;

namespace Peanut.Trade.TestTask.IntegrationService.Services
{
    public class ArbitrationService : IArbitrationService
    {
        private readonly IEnumerable<IExchangeClient> _exchangeClients;

        public ArbitrationService(IEnumerable<IExchangeClient> exchangeClients)
        {
            _exchangeClients = exchangeClients ?? throw new ArgumentNullException(nameof(exchangeClients));
        }

        public async Task<BestEstimatedOffer> GetBestEstimatedOfferAsync(decimal inputAmount, string inputCurrency, string outputCurrency)
        {
            var bestCurrencyLastPrice = new CurrencyLastPrice();
            var isInputCurrencyFirst = false;

            foreach (var exchangeClient in _exchangeClients)
            {
                var currencyLastPrice = await exchangeClient.GetCurrencyLastPriceAsync(inputCurrency, outputCurrency);

                if (bestCurrencyLastPrice.Price == 0)
                {
                    bestCurrencyLastPrice = currencyLastPrice;

                    continue;
                }

                isInputCurrencyFirst = currencyLastPrice.Symbol.StartsWith(inputCurrency, StringComparison.OrdinalIgnoreCase);

                if (!isInputCurrencyFirst && currencyLastPrice.Price < bestCurrencyLastPrice.Price)
                {
                    bestCurrencyLastPrice = currencyLastPrice;
                }
                else if (isInputCurrencyFirst && currencyLastPrice.Price > bestCurrencyLastPrice.Price)
                {
                    bestCurrencyLastPrice = currencyLastPrice;
                }
            }

            var bestEstimatedOffer = new BestEstimatedOffer
            {
                ExchangeName = bestCurrencyLastPrice.ExchangeName,
                OutputAmount = isInputCurrencyFirst
                    ? inputAmount * bestCurrencyLastPrice.Price
                    : inputAmount / bestCurrencyLastPrice.Price
            };

            return bestEstimatedOffer;
        }
    }
}
