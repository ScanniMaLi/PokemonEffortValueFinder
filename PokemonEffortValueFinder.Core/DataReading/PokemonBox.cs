namespace PokemonEffortValueFinder.Core.DataReading
{
    public class PokemonBox : IPokemonBox
    {
        readonly IDataReader dataReader;

        public PokemonBox(IDataReader dataReader)
        {
            this.dataReader = dataReader;
        }

        public async Task<Pokemon[]> WithdrawAll()
        {
            PokemonData pokemonData = await dataReader.GetData();
            List<Pokemon> pokemonList = new List<Pokemon>();

            foreach (EffortValueData effortValueData in pokemonData.EvData)
            {
                EffortValueYield ev = new EffortValueYield();

                ev.HealthPoints = effortValueData.Hp;
                ev.Attack = effortValueData.Attack;
                ev.Defense= effortValueData.Defense;
                ev.SpecialAttack= effortValueData.SpecialAttack;
                ev.SpecialDefense = effortValueData.SpecialDefense;
                ev.Speed= effortValueData.Speed;

                Pokemon pokemon = new Pokemon(effortValueData.Number, effortValueData.Name, effortValueData.IconUrl, ev);

                pokemon.DetailUrl= effortValueData.DetailUrl;
                pokemon.Form = effortValueData.Form;

                pokemonList.Add(pokemon);
            }

            return pokemonList.ToArray();
        }
    }


}
