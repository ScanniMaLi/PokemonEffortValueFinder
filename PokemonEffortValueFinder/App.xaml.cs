using PokemonEffortValueFinder.Core;
using PokemonEffortValueFinder.Core.DataReading;
using PokemonEffortValueFinder.Services;

namespace PokemonEffortValueFinder
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //ManualBox manualBox= new ManualBox();
            //manualBox.DepositPokemon(new Pokemon(1, "Bulbasaur", "https://img.pokemondb.net/sprites/sword-shield/icon/bulbasaur.png",new EffortValueYield {SpecialAttack=1}) { DetailUrl = "https://pokemondb.net/pokedex/bulbasaur"});
            //manualBox.DepositPokemon(new Pokemon(2, "Ivysaur", "https://img.pokemondb.net/sprites/sword-shield/icon/ivysaur.png",new EffortValueYield {SpecialAttack=1, SpecialDefense=1}) { DetailUrl = "https://pokemondb.net/pokedex/ivysaur"});
            //manualBox.DepositPokemon(new Pokemon(3, "Venusaur", "https://img.pokemondb.net/sprites/sword-shield/icon/venusaur.png",new EffortValueYield {SpecialAttack=2, SpecialDefense=1}) { DetailUrl = "https://pokemondb.net/pokedex/venusaur"});
            //manualBox.DepositPokemon(new Pokemon(4, "Venusaur", "https://img.pokemondb.net/sprites/sword-shield/icon/venusaur.png",new EffortValueYield {SpecialAttack=2, SpecialDefense=1}) { DetailUrl = "https://pokemondb.net/pokedex/venusaur"});
            //manualBox.DepositPokemon(new Pokemon(5, "Venusaur", "https://img.pokemondb.net/sprites/sword-shield/icon/venusaur.png",new EffortValueYield {SpecialAttack=2, SpecialDefense=1}) { DetailUrl = "https://pokemondb.net/pokedex/venusaur"});
            //manualBox.DepositPokemon(new Pokemon(6, "Venusaur", "https://img.pokemondb.net/sprites/sword-shield/icon/venusaur.png",new EffortValueYield {SpecialAttack=2, SpecialDefense=1}) {DetailUrl = "https://pokemondb.net/pokedex/venusaur"});

            MainPage = new AppShell(new PokemonBox(new DataReaderMAUI()));
        }
    }
}