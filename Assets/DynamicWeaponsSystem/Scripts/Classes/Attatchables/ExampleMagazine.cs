using DynamicWeaponsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace DynamicWeaponsSystem
{
    [ExecuteAlways]
    public class ExampleMagazine : MonoBehaviour, IAttatchable<ExampleStats>, IPrefabDisplayable<ExampleWeaponPositionEnum>
    {
        public string itemName = "Magazine";
        IWeapon<ExampleStats> weaponAttatchedTo;

        public ExampleStats statsHolder = new ExampleStats(maxAmmo: 15, bulletVelocity: 10);

        public GameObject displayPrefab;
        public ExampleWeaponPositionEnum slot;

        public void Attach(IWeapon<ExampleStats> weapon)
        {
            weaponAttatchedTo = weapon;

            IShooter<ExampleStats> shooter = GetComponent<IShooter<ExampleStats>>();
            if (shooter == null)
                return;

            weapon.SetShooter(shooter);

        }

        public void Detach()
        {
            Console.WriteLine("Detatched");
        }

        public IStattable<ExampleStats> GetStats()
        {
            return statsHolder;
        }

        public override string ToString()
        {
            return itemName;
        }


        public override bool Equals(object other)
        {
            if (other == null) return false;
            if (!(other is ExampleMagazine)) return false;

            return ((ExampleMagazine)other).name.Equals(this.name);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }

        public IStattable<ExampleStats> ApplyStats(IStattable<ExampleStats> stats)
        {

            return stats.AddStats(this.statsHolder);
        }

        public void PerformActions()
        {
            
        }

        public GameObject GetPrefab()
        {
            return displayPrefab;
        }

        public ExampleWeaponPositionEnum GetSlot()
        {
            return slot;
        }
    }
}
