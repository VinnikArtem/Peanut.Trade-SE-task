using Microsoft.AspNetCore.Http;
using Peanut.Trade.TestTask.IntegrationService.Builders;
using Peanut.Trade.TestTask.IntegrationService.Models;
using Peanut.Trade.TestTask.IntegrationService.Models.ClientSettings;

namespace Peanut.Trade.TestTask.IntegrationService.Extensions
{
    public static class ExchangeClientExtensions
    {
        public static (ApiRequestModel ApiRequest, string Symbol) GetGetLastPriceApiRequest(
            this BaseExchangeClientSettings settings,
            string inputCurrency,
            string outputCurrency,
            string query = "")
        {
            var symbol = settings.Symbols
                .Where(s => s.Contains(inputCurrency.ToUpper()) && s.Contains(outputCurrency.ToUpper()))
                .FirstOrDefault();

            var cancellationToken = new CancellationTokenSource();

            var apiRequest = new ApiRequestModelBuilder(settings.Domain)
                .Create(settings.ApiEndpoints.GetLastTrades, HttpMethods.Get, cancellationToken)
                .SetQueryString($"?{Constants.QueryParameters.Symbol}={symbol}{query}")
                .Build();

            return (apiRequest, symbol);
        }
    }
}
