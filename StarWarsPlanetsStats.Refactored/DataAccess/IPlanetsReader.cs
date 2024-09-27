public interface IPlanetsReader
{
    public Task<IEnumerable<Planet>> Read();
}