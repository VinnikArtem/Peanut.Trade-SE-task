namespace Peanut.Trade.TestTask.IntegrationService.Models
{
    /// <summary>
    /// Model of price from last trade on exchange
    /// </summary>
    public class CurrencyLastPrice
    {
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Exchange name
        /// </summary>
        public string ExchangeName { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; }
    }
}
