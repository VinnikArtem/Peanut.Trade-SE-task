using Newtonsoft.Json;

namespace Peanut.Trade.TestTask.IntegrationService.Models.Kucoin
{
    public class RecentTrade
    {
        [JsonProperty("sequence")]
        public string Sequence { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }
    }
}
