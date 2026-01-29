using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWeaponsSystem
{
    public interface IStattable<Stats> where Stats : IStattable<Stats>
    {

        Stats AddStats(Stats stats);

        Stats SubtractStats(Stats stats);

        Stats MultiplyStats(Stats stats);
    }
}
