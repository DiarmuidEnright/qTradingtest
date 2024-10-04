namespace QuantitativeTradingSystem.Indicators
{
    public interface IIndicator
    {
        List<double> Calculate(List<double> values);
    }
}
