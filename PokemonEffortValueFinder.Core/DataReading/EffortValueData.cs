using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEffortValueFinder.Core.DataReading
{
    public class EffortValueData
    {
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Form { get; set; } = string.Empty;
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set;}
        public int Speed { get; set; }
        public string IconUrl { get; set; } = string.Empty;
        public string DetailUrl { get; set; } = string.Empty;
    }
}
