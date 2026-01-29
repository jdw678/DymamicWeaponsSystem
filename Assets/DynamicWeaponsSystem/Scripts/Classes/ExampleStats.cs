using DynamicWeaponsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWeaponsSystem
{
    [Serializable]
    public class ExampleStats : IStattable<ExampleStats>
    {
        public float fireRate;
        public float damage;
        public float maxAmmo;
        public float currentAmmo;
        public float bulletVelocity;

        public ExampleStats(float fireRate = 0, float damage = 0, float maxAmmo = 0, float bulletVelocity = 0)
        {
            this.fireRate = fireRate;
            this.damage = damage;
            this.maxAmmo = maxAmmo;
            currentAmmo = maxAmmo;
            this.bulletVelocity = bulletVelocity;
        }

        public ExampleStats AddStats(ExampleStats stats)
        {
            fireRate += stats.fireRate;
            damage += stats.damage;
            maxAmmo += stats.maxAmmo;
            currentAmmo += stats.currentAmmo;
            bulletVelocity += stats.bulletVelocity;
            

            return this;
        }

        public ExampleStats MultiplyStats(ExampleStats stats)
        {
            fireRate *= stats.fireRate;
            damage *= stats.damage;
            this.maxAmmo *= maxAmmo;
            currentAmmo *= stats.currentAmmo;
            bulletVelocity *= stats.bulletVelocity;

            return this;
        }

        public ExampleStats SubtractStats(ExampleStats stats)
        {
            fireRate -= stats.fireRate;
            damage -= stats.damage;
            this.maxAmmo -= maxAmmo;
            currentAmmo -= stats.currentAmmo;
            bulletVelocity -= stats.bulletVelocity;

            return this;
        }

        public ExampleStats Clone()
        {
            return new ExampleStats(fireRate, damage, maxAmmo);
        }

    }
}
