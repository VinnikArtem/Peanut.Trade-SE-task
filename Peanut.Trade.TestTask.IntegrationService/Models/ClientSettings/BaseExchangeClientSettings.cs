namespace Peanut.Trade.TestTask.IntegrationService.Models.ClientSettings
{
    public class BaseExchangeClientSettings
    {
        public string Name { get; set; }

        public string Domain { get; set; }

        public ApiEndpoints ApiEndpoints { get; set; }

        public IEnumerable<string> Symbols { get; set; }
    }

    public class ApiEndpoints
    {
        public string GetLastTrades { get; set; }
    }
}
