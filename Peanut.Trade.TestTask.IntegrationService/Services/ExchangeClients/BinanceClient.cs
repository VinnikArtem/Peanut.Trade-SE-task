﻿using Peanut.Trade.TestTask.IntegrationService.Extensions;
using Peanut.Trade.TestTask.IntegrationService.Models;
using Peanut.Trade.TestTask.IntegrationService.Models.Binance;
using Peanut.Trade.TestTask.IntegrationService.Models.ClientSettings;
using Peanut.Trade.TestTask.IntegrationService.Services.Interfaces;

namespace Peanut.Trade.TestTask.IntegrationService.Services.ExchangeClients
{
    public class BinanceClient : IExchangeClient
    {
        private const int LastTrade = 1;

        private readonly IApiService _apiService;
        private readonly BaseExchangeClientSettings _exchangeClientSettings;

        public BinanceClient(IApiService apiService, BaseExchangeClientSettings exchangeClientSettings)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            _exchangeClientSettings = exchangeClientSettings ?? throw new ArgumentNullException(nameof(exchangeClientSettings));
        }

        public async Task<CurrencyLastPrice> GetCurrencyLastPriceAsync(string inputCurrency, string outputCurrency)
        {
            var (apiRequest, symbol) = _exchangeClientSettings.GetGetLastPriceApiRequest(
                inputCurrency,
                outputCurrency,
                $"&{Constants.QueryParameters.Limit}={LastTrade}");
            
            var recentTrades = await _apiService.SendRequestAsync<IEnumerable<RecentTrade>>(apiRequest);

            if (recentTrades == null || !recentTrades.Any()) return new CurrencyLastPrice();
            
            var lastTrade = recentTrades.FirstOrDefault();

            return new CurrencyLastPrice
            {
                Price = lastTrade.Price,
                ExchangeName = _exchangeClientSettings.Name,
                Symbol = symbol
            };
        }
    }
}
