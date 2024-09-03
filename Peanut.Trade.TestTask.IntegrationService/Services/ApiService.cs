using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Peanut.Trade.TestTask.IntegrationService.Models;
using Peanut.Trade.TestTask.IntegrationService.Services.Interfaces;
using System.Text;

namespace Peanut.Trade.TestTask.IntegrationService.Services
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _httpClientName;

        public ApiService(IHttpClientFactory httpClientFactory, string httpClientName)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpClientName = httpClientName ?? throw new ArgumentNullException(nameof(httpClientName));
        }

        public async Task<T> SendRequestAsync<T>(ApiRequestModel apiRequestModel)
        {
            ArgumentNullException.ThrowIfNull(apiRequestModel);

            var requestMessage = CreateRequestMessage(apiRequestModel);

            var response = await _httpClientFactory
                .CreateClient(GetHttpClientName(apiRequestModel))
                .SendAsync(requestMessage, apiRequestModel.CancellationToken);

            if (!response.IsSuccessStatusCode) return default;

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        private HttpRequestMessage CreateRequestMessage(ApiRequestModel apiRequestModel)
        {
            ArgumentNullException.ThrowIfNull(apiRequestModel);
            ArgumentNullException.ThrowIfNull(apiRequestModel.Url);

            var requestMessage = new HttpRequestMessage(
                new HttpMethod(apiRequestModel.Method),
                apiRequestModel.Url);

            if (apiRequestModel.Method != HttpMethods.Get && apiRequestModel.Method != HttpMethods.Delete)
            {
                requestMessage.Content = new StringContent(
                    apiRequestModel.Content,
                    Encoding.UTF8,
                    apiRequestModel.ContentType);
            }

            foreach (var (key, value) in apiRequestModel.Headers)
            {
                requestMessage.Headers.Add(key, value);
            }

            return requestMessage;
        }

        private string GetHttpClientName(ApiRequestModel apiRequestModel)
        {
            return !string.IsNullOrEmpty(apiRequestModel.HttpClientName) ? apiRequestModel.HttpClientName : _httpClientName;
        }
    }
}
