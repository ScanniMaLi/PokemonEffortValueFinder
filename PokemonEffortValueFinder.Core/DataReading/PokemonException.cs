using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEffortValueFinder.Core.DataReading
{
    public class PokemonException : Exception
    {
        public PokemonException(Exception? innerException) : base("Could not load Data.", innerException)
        {
        }
    }
}
