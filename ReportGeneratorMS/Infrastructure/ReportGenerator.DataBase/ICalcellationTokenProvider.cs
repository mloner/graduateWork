namespace GeneratorDataBase
{
    public interface ICalcellationTokenProvider
    {
        CancellationToken CancellationToken { get; }
    }
}