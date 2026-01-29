
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicWeaponsSystem
{
    public class ExampleBarrel : MonoBehaviour, IAttatchable<ExampleStats>, IPrefabDisplayable<ExampleWeaponPositionEnum>
    {
        string attatchmentName = "Barrel";

        [SerializeField]
        ExampleStats stats = new ExampleStats(fireRate: 10, bulletVelocity: 10);

        [SerializeField]
        GameObject prefab;

        [SerializeField]
        ExampleWeaponPositionEnum slot = ExampleWeaponPositionEnum.Barrel;

        [SerializeField]
        GameObject positionToFireFrom;

        public IStattable<ExampleStats> ApplyStats(IStattable<ExampleStats> stats)
        {
            return stats.AddStats(this.stats);
        }

        public void Attach(IWeapon<ExampleStats> weapon)
        {
            weapon.GetShooter().SetPositionToFireFromObj(positionToFireFrom);
        }

        public void Detach()
        {
            return;
        }

        public GameObject GetPrefab()
        {
            return prefab;
        }

        public ExampleWeaponPositionEnum GetSlot()
        {
            return slot;
        }

        public IStattable<ExampleStats> GetStats()
        {
            return stats;
        }

        public void PerformActions()
        {
            return;
        }

        public override string ToString()
        {
            return attatchmentName;
        }
    }


}