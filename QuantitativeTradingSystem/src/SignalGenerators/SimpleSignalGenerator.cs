using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantitativeTradingSystem.SignalGenerators
{
    public class SimpleSignalGenerator : ISignalGenerator
    {
        public List<Signal> GenerateSignal(List<PriceData> data)
        {
            var signals = new List<Signal>();

            var shortTermSMA = new MovingAverageIndicator(10).Calculate(data.Select(d => d.Close).ToList());
            var longTermSMA = new MovingAverageIndicator(30).Calculate(data.Select(d => d.Close).ToList());

            for (int i = 1; i < shortTermSMA.Count; i++)
            {
                if (shortTermSMA[i] > longTermSMA[i] && shortTermSMA[i - 1] <= longTermSMA[i - 1])
                {
                    signals.Add(new Signal
                    {
                        Date = data[i + 29].Date,
                        Type = "buy"
                    });
                }
                else if (shortTermSMA[i] < longTermSMA[i] && shortTermSMA[i - 1] >= longTermSMA[i - 1])
                {
                    signals.Add(new Signal
                    {
                        Date = data[i + 29].Date,
                        Type = "sell"
                    });
                }
            }

            return signals;
        }
    }
}
