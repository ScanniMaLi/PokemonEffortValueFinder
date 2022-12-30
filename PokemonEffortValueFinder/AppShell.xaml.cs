using PokemonEffortValueFinder.Core;

namespace PokemonEffortValueFinder
{
    public partial class AppShell : Shell
    {
        public AppShell(IPokemonBox pokemonBox)
        {
            InitializeComponent();
            shellContent.Content = new MainPage(pokemonBox);
        }
    }
}