using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantitativeTradingSystem.Indicators
{
    public class MovingAverageIndicator : IIndicator
    {
        private readonly int _period;

        public MovingAverageIndicator(int period)
        {
            _period = period;
        }

        public List<double> Calculate(List<double> values)
        {
            var movingAverages = new List<double>();

            for (int i = 0; i <= values.Count - _period; i++)
            {
                var average = values.Skip(i).Take(_period).Average();
                movingAverages.Add(average);
            }

            return movingAverages;
        }
    }
}
