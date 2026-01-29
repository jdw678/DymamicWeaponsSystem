using DynamicWeaponsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace DynamicWeaponsSystem
{
    [ExecuteAlways]
    public class ExampleBulletShooter : MonoBehaviour, IShooter<ExampleStats>
    {
        public ExampleBullet bulletPrefab;
        [SerializeField]
        GameObject positionToFireFrom;

        public void SetPositionToFireFromObj(GameObject positionToFireFrom)
        {
            this.positionToFireFrom = positionToFireFrom;
        }

        public void Shoot(ExampleStats stats, Quaternion angle)
        {
            if (bulletPrefab == null)
                throw new Exception("Bullet Prefab Was Null!");

            ExampleBullet bullet = Instantiate(bulletPrefab, positionToFireFrom.transform.position, angle);
            bullet.SetSpeed(stats.bulletVelocity);
        }
    }
}
