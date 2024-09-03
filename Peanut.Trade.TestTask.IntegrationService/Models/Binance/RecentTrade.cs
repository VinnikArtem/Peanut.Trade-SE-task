using Newtonsoft.Json;

namespace Peanut.Trade.TestTask.IntegrationService.Models.Binance
{
    public class RecentTrade
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// The total number of coins available at a specific price point.
        /// </summary>
        [JsonProperty("qty")]
        public double Qty { get; set; }

        [JsonProperty("quoteQty")]
        public decimal QuoteQty { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("isBuyerMaker")]
        public bool IsBuyerMaker { get; set; }

        [JsonProperty("isBestMatch")]
        public bool IsBestMatch { get; set; }
    }
}
