using Newtonsoft.Json;

namespace Peanut.Trade.TestTask.IntegrationService.Models
{
    public class BestEstimatedOffer
    {
        [JsonProperty("outputAmount")]
        public decimal OutputAmount { get; set; }

        [JsonProperty("exchangeName")]
        public string ExchangeName { get; set; }
    }
}
