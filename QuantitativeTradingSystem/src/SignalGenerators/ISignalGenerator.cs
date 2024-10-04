namespace QuantitativeTradingSystem.SignalGenerators
{
    public interface ISignalGenerator
    {
        List<Signal> GenerateSignal(List<PriceData> data);
    }

    public class Signal
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }
}
