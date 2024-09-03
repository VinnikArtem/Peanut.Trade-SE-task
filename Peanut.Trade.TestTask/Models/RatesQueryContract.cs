namespace Peanut.Trade.TestTask.Models
{
    /// <summary>
    /// Mapping parameters from query to get rates from all exchanges
    /// </summary>
    public class RatesQueryContract
    {
        /// <summary>
        /// Base currency
        /// </summary>
        public string BaseCurrency { get; set; }

        /// <summary>
        /// Quote currency
        /// </summary>
        public string QuoteCurrency { get; set; }
    }
}
