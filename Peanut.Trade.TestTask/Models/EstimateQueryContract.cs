namespace Peanut.Trade.TestTask.Models
{
    /// <summary>QueryContract
    /// Mapping parameters from query to estimate best offer
    /// </summary>
    public class EstimateQueryContract
    {
        /// <summary>
        /// Input amount parameter
        /// </summary>
        public decimal InputAmount { get; set; }

        /// <summary>
        /// Input currency parameter
        /// </summary>
        public string InputCurrency { get; set; }

        /// <summary>
        /// Output currency parameter
        /// </summary>
        public string OutputCurrency { get; set; }
    }
}
