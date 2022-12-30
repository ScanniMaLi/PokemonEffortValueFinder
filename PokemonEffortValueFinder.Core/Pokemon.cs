namespace PokemonEffortValueFinder.Core
{
    public class Pokemon
    {
        public Pokemon(int number,
                       string name,
                       string iconUrl,
                       EffortValueYield effortValueYield)
        {
            Number = number;
            Name = name;
            IconUrl = iconUrl;
            EffortValueYield = effortValueYield;
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string DetailUrl { get; set; } = string.Empty;
        public EffortValueYield EffortValueYield { get; set; }

        public string Form { get; set; } = string.Empty;
    }
}