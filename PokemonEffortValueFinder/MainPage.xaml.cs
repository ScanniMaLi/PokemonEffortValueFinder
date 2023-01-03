using PokemonEffortValueFinder.Core;
using PokemonEffortValueFinder.Core.DataReading;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace PokemonEffortValueFinder
{
    public partial class MainPage : ContentPage
    {
        public class EffortValueName
        {
            public EffortValueName(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public int Id { get; set; }
            public string Name { get; set; }
        }

        public MainPage(IPokemonBox pokemonBox)
        {
            DetailCommand = new DetailCommand();
            PokemonBox = pokemonBox;
            SelectedEffortValueName = this.EffortValueNames[0];
            BindingContext = this;
            InitializeComponent();

            this.Loaded += MainPage_Loaded;
        }

        public ICommand DetailCommand { get; }

        private List<Pokemon> allPokemon = new List<Pokemon>();
        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            pokemonList.Clear();
            Pokemon[] withdrawnPkmn;
            try
            {
                withdrawnPkmn = await PokemonBox.WithdrawAll();
            }
            catch (PokemonException ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
                App.Current.Quit();
                return;
            }

            foreach (Pokemon pkmn in withdrawnPkmn)
            {
                this.pokemonList.Add(pkmn);
                this.allPokemon.Add(pkmn);
            }
        }

        public const int EffortIdAll = -1;
        public const int EffortIdHp = 0;
        public const int EffortIdAttack = 1;
        public const int EffortIdDefense = 2;
        public const int EffortIdSpecialAttack = 3;
        public const int EffortIdSpecialDefense = 4;
        public const int EffortIdSpeed = 5;
        private void FilterPokemon()
        {
            pokemonList.Clear();
            foreach (Pokemon pkmn in allPokemon)
            {
                if (string.IsNullOrWhiteSpace(pokemonName) || pkmn.Name.Contains(PokemonName,StringComparison.OrdinalIgnoreCase))
                {
                    if (selectedEffortValueName.Id == EffortIdAll)
                    {
                        this.pokemonList.Add(pkmn);
                    }
                    else if (selectedEffortValueName.Id == EffortIdHp && pkmn.EffortValueYield.HealthPoints > 0)
                    {
                        this.pokemonList.Add(pkmn);
                    }
                    else if (selectedEffortValueName.Id == EffortIdAttack && pkmn.EffortValueYield.Attack > 0)
                    {
                        this.pokemonList.Add(pkmn);
                    }
                    else if (selectedEffortValueName.Id == EffortIdDefense && pkmn.EffortValueYield.Defense > 0)
                    {
                        this.pokemonList.Add(pkmn);
                    }
                    else if (selectedEffortValueName.Id == EffortIdSpecialAttack && pkmn.EffortValueYield.SpecialAttack > 0)
                    {
                        this.pokemonList.Add(pkmn);
                    }
                    else if (selectedEffortValueName.Id == EffortIdSpecialDefense && pkmn.EffortValueYield.SpecialDefense > 0)
                    {
                        this.pokemonList.Add(pkmn);
                    }
                    else if (selectedEffortValueName.Id == EffortIdSpeed && pkmn.EffortValueYield.Speed > 0)
                    {
                        this.pokemonList.Add(pkmn);
                    }
                }
            }
        }

        private void SortPokemon()
        {
            IEnumerable<Pokemon> sortedPokemon;

            if (selectedEffortValueName.Id == EffortIdHp)
            {
                sortedPokemon = pokemonList.OrderByDescending(pkmn => pkmn.EffortValueYield.HealthPoints).ThenByDescending(pkmn => pkmn.Number);
            }
            else if (selectedEffortValueName.Id == EffortIdAttack)
            {
                sortedPokemon = pokemonList.OrderByDescending(pkmn => pkmn.EffortValueYield.Attack).ThenByDescending(pkmn => pkmn.Number);
            }
            else if (selectedEffortValueName.Id == EffortIdDefense)
            {
                sortedPokemon = pokemonList.OrderByDescending(pkmn => pkmn.EffortValueYield.Defense).ThenByDescending(pkmn => pkmn.Number);
            }
            else if (selectedEffortValueName.Id == EffortIdSpecialAttack)
            {
                sortedPokemon = pokemonList.OrderByDescending(pkmn => pkmn.EffortValueYield.SpecialAttack).ThenByDescending(pkmn => pkmn.Number);
            }
            else if (selectedEffortValueName.Id == EffortIdSpecialDefense)
            {
                sortedPokemon = pokemonList.OrderByDescending(pkmn => pkmn.EffortValueYield.SpecialDefense).ThenByDescending(pkmn => pkmn.Number);
            }
            else if (selectedEffortValueName.Id == EffortIdSpeed)
            {
                sortedPokemon = pokemonList.OrderByDescending(pkmn => pkmn.EffortValueYield.Speed).ThenByDescending(pkmn => pkmn.Number);
            }
            else
            {
                return;
            }
            sortedPokemon = sortedPokemon.ToList();
            pokemonList.Clear();
            foreach (var pokemon in sortedPokemon)
            {
                pokemonList.Add(pokemon);
            }
        }

        private EffortValueName[] effortValueNames = new EffortValueName[]
        {
            new EffortValueName(EffortIdAll, "All"),
            new EffortValueName(EffortIdHp, "HP"),
            new EffortValueName(EffortIdAttack, "Attack"),
            new EffortValueName(EffortIdDefense, "Defense"),
            new EffortValueName(EffortIdSpecialAttack, "Special Attack"),
            new EffortValueName(EffortIdSpecialDefense, "Special Defense"),
            new EffortValueName(EffortIdSpeed, "Speed")
        };
        private EffortValueName selectedEffortValueName;

        public EffortValueName SelectedEffortValueName
        {
            get { return selectedEffortValueName; }
            set
            {
                selectedEffortValueName = value;
                this.OnPropertyChanged(nameof(SelectedEffortValueName));
            }
        }
        public EffortValueName[] EffortValueNames
        {
            get { return effortValueNames; }
        }

        private ObservableCollection<Pokemon> pokemonList = new ObservableCollection<Pokemon>();

        public ObservableCollection<Pokemon> PokemonList
        {
            get { return pokemonList; }
        }

        public IPokemonBox PokemonBox { get; }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(SelectedEffortValueName.Name);
            this.FilterPokemon();
            this.SortPokemon();
        }

        private void EntryPokemonName_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.FilterPokemon();
            this.SortPokemon();
        }

        private string pokemonName = string.Empty;
        public string PokemonName
        {
            get
            {
                return pokemonName;
            }

            set
            {
                pokemonName = value;
                this.OnPropertyChanged(nameof(PokemonName));
            }
        }
    }
}