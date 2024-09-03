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
            var isInputCurrencyFirstInSymbol = false;

            foreach (var exchangeClient in _exchangeClients)
            {
                var currencyLastPrice = await exchangeClient.GetCurrencyLastPriceAsync(inputCurrency, outputCurrency);

                if (bestCurrencyLastPrice.Price == 0)
                {
                    bestCurrencyLastPrice = currencyLastPrice;

                    continue;
                }

                isInputCurrencyFirstInSymbol = currencyLastPrice.Symbol.StartsWith(inputCurrency, StringComparison.OrdinalIgnoreCase);

                if (!isInputCurrencyFirstInSymbol && currencyLastPrice.Price < bestCurrencyLastPrice.Price)
                {
                    bestCurrencyLastPrice = currencyLastPrice;
                }
                else if (isInputCurrencyFirstInSymbol && currencyLastPrice.Price > bestCurrencyLastPrice.Price)
                {
                    bestCurrencyLastPrice = currencyLastPrice;
                }
            }

            var bestEstimatedOffer = new BestEstimatedOffer
            {
                ExchangeName = bestCurrencyLastPrice.ExchangeName,
                OutputAmount = isInputCurrencyFirstInSymbol
                    ? inputAmount * bestCurrencyLastPrice.Price
                    : inputAmount / bestCurrencyLastPrice.Price
            };

            return bestEstimatedOffer;
        }

        public async Task<IEnumerable<CryptoRate>> GetRatesAsync(string baseCurrency, string quoteCurrency)
        {
            var rates = new List<CryptoRate>();

            foreach (var exchangeClient in _exchangeClients)
            {
                var currencyLastPrice = await exchangeClient.GetCurrencyLastPriceAsync(baseCurrency, quoteCurrency);

                var isInputCurrencyFirstInSymbol = currencyLastPrice.Symbol.StartsWith(baseCurrency, StringComparison.OrdinalIgnoreCase);

                rates.Add(new CryptoRate
                {
                    ExchangeName = currencyLastPrice.ExchangeName,
                    Rate = isInputCurrencyFirstInSymbol
                        ? currencyLastPrice.Price
                        : 1 / currencyLastPrice.Price
                });
            }

            return rates;
        }
    }
}
