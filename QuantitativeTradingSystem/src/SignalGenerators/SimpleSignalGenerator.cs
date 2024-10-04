namespace QuantitativeTradingSystem.SignalGenerators
{
    public class SimpleSignalGenerator : ISignalGenerator
    {
        public List<Signal> GenerateSignal(List<PriceData> data)
        {
            return new List<Signal>();
        }
    }
}
