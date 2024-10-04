using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantitativeTradingSystem.Indicators
{
    public class BollingerBandsIndicator : IIndicator
    {
        private readonly int _period;
        private readonly double _standardDeviations;

        public BollingerBandsIndicator(int period, double standardDeviations)
        {
            _period = period;
            _standardDeviations = standardDeviations;
        }

        public List<double> Calculate(List<double> values)
        {
            var bands = new List<double>();

            for (int i = 0; i <= values.Count - _period; i++)
            {
                var window = values.Skip(i).Take(_period).ToList();
                double sma = window.Average();
                double stdDev = Math.Sqrt(window.Average(v => Math.Pow(v - sma, 2)));

                double upperBand = sma + _standardDeviations * stdDev;
                double lowerBand = sma - _standardDeviations * stdDev;
                bands.Add(upperBand);
                bands.Add(sma);
                bands.Add(lowerBand);
            }

            return bands;
        }
    }
}
