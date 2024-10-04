using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuantitativeTradingSystem.DataFeed
{
    public class YahooFinanceDataFeed : IDataFeed
    {
        private readonly HttpClient _client;

        public YahooFinanceDataFeed()
        {
            _client = new HttpClient();
        }

        public async Task<List<PriceData>> GetHistoricalData(string symbol, DateTime startDate, DateTime endDate)
        {
            string url = $"https://query1.finance.yahoo.com/v7/finance/download/{symbol}?period1={((DateTimeOffset)startDate).ToUnixTimeSeconds()}&period2={((DateTimeOffset)endDate).ToUnixTimeSeconds()}&interval=1d&events=history";
            
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string csvData = await response.Content.ReadAsStringAsync();
            return ParseCsvToPriceData(csvData);
        }

        private List<PriceData> ParseCsvToPriceData(string csvData)
        {
            var priceDataList = new List<PriceData>();
            var rows = csvData.Split('\n');
            
            for (int i = 1; i < rows.Length; i++)
            {
                var columns = rows[i].Split(',');
                if (columns.Length < 6) continue;
                
                var priceData = new PriceData
                {
                    Date = DateTime.Parse(columns[0]),
                    Open = double.Parse(columns[1]),
                    High = double.Parse(columns[2]),
                    Low = double.Parse(columns[3]),
                    Close = double.Parse(columns[4]),
                    Volume = double.Parse(columns[5])
                };
                priceDataList.Add(priceData);
            }

            return priceDataList;
        }
    }
}
