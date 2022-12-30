using PokemonEffortValueFinder.Core.DataReading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokemonEffortValueFinder.Services
{
    public class DataReaderMAUI : IDataReader
    {
        public async Task<PokemonData> GetData()
        {
            PokemonData pokemonData; 

            try
            {
                using var stremm = await FileSystem.OpenAppPackageFileAsync("PokemonEvData.json");
                using var reader = new StreamReader(stremm);

                string fileContent = await reader.ReadToEndAsync();
                pokemonData = JsonSerializer.Deserialize<PokemonData>(fileContent, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            catch (Exception ex)
            {
                throw new PokemonException(ex);
            }

            return pokemonData;

        }
    }
}
