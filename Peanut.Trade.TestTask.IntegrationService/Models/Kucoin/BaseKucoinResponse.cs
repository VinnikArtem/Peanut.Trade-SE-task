using Newtonsoft.Json;

namespace Peanut.Trade.TestTask.IntegrationService.Models.Kucoin
{
    public class BaseKucoinResponse<T>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
