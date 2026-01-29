using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DynamicWeaponsSystem
{
    public class ExampleBullet : MonoBehaviour
    {
        float speed = 0;

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
