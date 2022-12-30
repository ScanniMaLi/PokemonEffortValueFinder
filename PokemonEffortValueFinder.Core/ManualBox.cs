namespace PokemonEffortValueFinder.Core
{
    public class ManualBox : IPokemonBox
    {
        private List<Pokemon> pokemon = new List<Pokemon>();

        public Task<Pokemon[]> WithdrawAll()
        {
            Pokemon[] piglimeg = pokemon.ToArray();
            return Task.FromResult(piglimeg);
        }

        public bool DepositPokemon(Pokemon piglimeg)
        {
            if (!pokemon.Contains(piglimeg))
            {
                pokemon.Add(piglimeg);
                return true;
            }
            else 
            { 
                return false; 
            }
        }
    }
}
