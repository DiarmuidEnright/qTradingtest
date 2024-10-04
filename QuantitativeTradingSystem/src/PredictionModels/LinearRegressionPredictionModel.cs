using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearRegression;

namespace QuantitativeTradingSystem.PredictionModels
{
    public class LinearRegressionPredictionModel : IPredictionModel
    {
        public double Predict(List<double> inputData)
        {
            var xData = new List<double>();
            var yData = new List<double>();

            for (int i = 0; i < inputData.Count; i++)
            {
                xData.Add(i);
                yData.Add(inputData[i]);
            }

            (double intercept, double slope) = SimpleRegression.Fit(xData.ToArray(), yData.ToArray());

            return intercept + slope * inputData.Count;
        }
    }
}
