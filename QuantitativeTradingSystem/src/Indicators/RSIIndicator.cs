using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantitativeTradingSystem.Indicators
{
    public class RSIIndicator : IIndicator
    {
        private readonly int _period;

        public RSIIndicator(int period)
        {
            _period = period;
        }

        public List<double> Calculate(List<double> values)
        {
            var gains = new List<double>();
            var losses = new List<double>();

            for (int i = 1; i < values.Count; i++)
            {
                double change = values[i] - values[i - 1];
                if (change > 0)
                    gains.Add(change);
                else
                    losses.Add(Math.Abs(change));
            }

            double avgGain = gains.Take(_period).Average();
            double avgLoss = losses.Take(_period).Average();
            var rsi = new List<double>();

            for (int i = _period; i < values.Count; i++)
            {
                double rs = avgGain / avgLoss;
                double rsiValue = 100 - (100 / (1 + rs));
                rsi.Add(rsiValue);

                double gain = values[i] > values[i - 1] ? values[i] - values[i - 1] : 0;
                double loss = values[i] < values[i - 1] ? values[i - 1] - values[i] : 0;
                avgGain = ((avgGain * (_period - 1)) + gain) / _period;
                avgLoss = ((avgLoss * (_period - 1)) + loss) / _period;
            }

            return rsi;
        }
    }
}
