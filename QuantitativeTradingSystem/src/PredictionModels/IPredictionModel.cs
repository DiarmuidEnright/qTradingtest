namespace QuantitativeTradingSystem.PredictionModels
{
    public interface IPredictionModel
    {
        double Predict(List<double> inputData);
    }
}
