using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DynamicWeaponsSystem
{
    public interface IShooter<Stats> where Stats : IStattable<Stats>
    {
        void Shoot(Stats stats, Quaternion angle);
        void SetPositionToFireFromObj(GameObject positionToFireFrom);
    }
}
