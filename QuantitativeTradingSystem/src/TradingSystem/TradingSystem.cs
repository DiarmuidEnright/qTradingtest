using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantitativeTradingSystem.TradingSystem
{
    public class TradingSystem
    {
        private readonly IDataFeed _dataFeed;
        private readonly IIndicator _indicator;
        private readonly ISignalGenerator _signalGenerator;
        private readonly IPredictionModel _predictionModel;

        public TradingSystem(
            IDataFeed dataFeed,
            IIndicator indicator,
            ISignalGenerator signalGenerator,
            IPredictionModel predictionModel)
        {
            _dataFeed = dataFeed;
            _indicator = indicator;
            _signalGenerator = signalGenerator;
            _predictionModel = predictionModel;
        }

        public void Run(string symbol, DateTime startDate, DateTime endDate)
        {
            var data = _dataFeed.GetHistoricalData(symbol, startDate, endDate).Result;
            var closingPrices = data.Select(d => d.Close).ToList();
            var indicatorValues = _indicator.Calculate(closingPrices);
            var signals = _signalGenerator.GenerateSignal(data);
            var prediction = _predictionModel.Predict(indicatorValues);

            foreach (var signal in signals)
            {
                Console.WriteLine($"Date: {signal.Date}, Signal: {signal.Type}");
            }

            Console.WriteLine($"Prediction for next price: {prediction}");
        }
    }
}
