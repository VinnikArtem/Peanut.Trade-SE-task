using Microsoft.AspNetCore.Http;

namespace Peanut.Trade.TestTask.IntegrationService.Models
{
    public class ApiRequestModel : ICloneable
    {
        public string HttpClientName { get; set; }

        public string ContentType { get; set; } = Constants.ContentTypes.JsonContentType;

        public string Content { get; set; }

        public CancellationTokenSource CancellationTokenSource { get; }

        public CancellationToken CancellationToken => CancellationTokenSource.Token;

        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        public string Method { get; set; } = HttpMethods.Get;

        public Uri Url { get; set; }

        public ApiRequestModel(CancellationTokenSource cancellationTokenSource)
        {
            CancellationTokenSource = cancellationTokenSource;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
