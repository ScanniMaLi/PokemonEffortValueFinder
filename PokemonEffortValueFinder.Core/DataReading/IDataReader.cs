namespace PokemonEffortValueFinder.Core.DataReading
{
    public interface IDataReader
    {
        Task<PokemonData> GetData();
    }
}