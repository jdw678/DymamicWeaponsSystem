using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWeaponsSystem
{
    public interface IWeapon<Stats> where Stats : IStattable<Stats>
    {
        void Attatch(IAttatchable<Stats> attachable);

        IStattable<Stats> GetStats();

        void SetStats(IStattable<Stats> stats);

        bool IsShooting();

        void SetShooter(IShooter<Stats> shooter);

        IShooter<Stats> GetShooter();

    }
}
