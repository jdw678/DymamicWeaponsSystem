using DynamicWeaponsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DynamicWeaponsSystem
{
    [ExecuteAlways]
    public class WeaponPrefabHandler : MonoBehaviour, IPrefabDisplayer<ExampleWeaponPositionEnum>
    {

        public List<ISlotter<ExampleWeaponPositionEnum>> slots;

        private void Awake()
        {
            FindChildren();

        }

        public void FindChildren()
        {

            slots = gameObject.GetComponentsInChildren<ISlotter<ExampleWeaponPositionEnum>>().ToList();
        }

        public void DisplayPrefab(GameObject prefab, ExampleWeaponPositionEnum slot)
        {
            ISlotter<ExampleWeaponPositionEnum> slotter = slots.Find(x => x.GetSlot().Equals(slot));
            if (slotter == null)
                throw new Exception("No slot of that type attatched!");

            slotter.SetPrefab(prefab);

        }

        private void OnValidate()
        {
            FindChildren();
        }

    }
}
