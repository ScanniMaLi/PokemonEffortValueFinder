using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEffortValueFinder.Core
{
    public interface IPokemonBox
    {
        Task<Pokemon[]> WithdrawAll();
    }
}
