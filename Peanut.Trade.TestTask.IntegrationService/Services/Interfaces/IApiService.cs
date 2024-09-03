using Peanut.Trade.TestTask.IntegrationService.Models;

namespace Peanut.Trade.TestTask.IntegrationService.Services.Interfaces
{
    public interface IApiService
    {
        /// <summary>
        /// Sends request through HTTP Client according to data provided.
        /// </summary>
        /// <param name="apiRequestModel">Contains content, headers, content type, method, url, cancellation token.</param>
        /// <typeparam name="T">Return type parameter</typeparam>
        Task<T> SendRequestAsync<T>(ApiRequestModel apiRequestModel);
    }
}
