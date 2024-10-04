namespace QuantitativeTradingSystem.DataFeed
{
    public class QuandlDataFeed : IDataFeed
    {
        public List<PriceData> GetHistoricalData(string symbol, DateTime startDate, DateTime endDate)
        {
            return new List<PriceData>();
        }
    }
}
