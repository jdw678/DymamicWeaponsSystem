using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DynamicWeaponsSystem
{
    public interface ISlotter<Slot>
    {
        Slot GetSlot();
        void SetPrefab(GameObject prefab);
    }
}
