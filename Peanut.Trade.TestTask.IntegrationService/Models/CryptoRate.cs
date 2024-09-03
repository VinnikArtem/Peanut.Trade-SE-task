using Newtonsoft.Json;

namespace Peanut.Trade.TestTask.IntegrationService.Models
{
    public class CryptoRate
    {
        [JsonProperty("exchangeName")]
        public string ExchangeName { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }
}
