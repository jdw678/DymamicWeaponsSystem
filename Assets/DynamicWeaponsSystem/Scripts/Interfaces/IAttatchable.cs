using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWeaponsSystem
{
    public interface IAttatchable<Stats> where Stats : IStattable<Stats>
    {



        void Attach(IWeapon<Stats> weapon);

        void Detach();

        IStattable<Stats> GetStats();

        IStattable<Stats> ApplyStats(IStattable<Stats> stats);

        void PerformActions();
    }
}
