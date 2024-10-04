using System.Collections.Generic;
using Accord.Neuro;
using Accord.Neuro.Learning;
using Accord.Neuro.Networks;

namespace QuantitativeTradingSystem.PredictionModels
{
    public class NeuralNetworkPredictionModel : IPredictionModel
    {
        private readonly ActivationNetwork _network;
        private readonly BackPropagationLearning _teacher;

        public NeuralNetworkPredictionModel()
        {
            _network = new ActivationNetwork(new SigmoidFunction(), 1, 10, 1);
            _teacher = new BackPropagationLearning(_network);
        }

        public double Predict(List<double> inputData)
        {
            var inputs = new double[inputData.Count];
            var outputs = new double[inputData.Count];

            for (int i = 0; i < inputData.Count; i++)
            {
                inputs[i] = inputData[i];
                outputs[i] = inputData[i];
            }

            _teacher.RunEpoch(inputs, outputs);
            return _network.Compute(new[] { inputData[^1] })[0];
        }
    }
}
