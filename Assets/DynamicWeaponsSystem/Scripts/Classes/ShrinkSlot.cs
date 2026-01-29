using DynamicWeaponsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DynamicWeaponsSystem
{
    public class ShrinkSlot : MonoBehaviour, ISlotter<ExampleWeaponPositionEnum>
    {
        [SerializeField]
        ExampleWeaponPositionEnum slot;
        [SerializeField]
        GameObject prefab;
        [SerializeField]
        GameObject instantiation;
        public ShrinkSlot(ExampleWeaponPositionEnum slot)
        {
            this.slot = slot;
        }

        public ExampleWeaponPositionEnum GetSlot()
        {
            return slot;
        }

        public void SetPrefab(GameObject prefab)
        {
            this.prefab = prefab;
            if(instantiation != null)
            {
                if(Application.isPlaying)
                    Destroy(instantiation);
                else
                    DestroyImmediate(instantiation);
                    
            }

            InstantiatePrefab();
                
        }


        void InstantiatePrefab()
        {

            instantiation = Instantiate(prefab, transform);
            instantiation.transform.rotation = transform.rotation;
            Renderer prefabRend = instantiation.GetComponent<Renderer>();
            Renderer slotRend = GetComponent<Renderer>();


            Vector3 prefabScale = prefabRend.bounds.size; //instantiation.transform.localScale;
            Vector3 slotScale = slotRend.bounds.size; //transform.localScale;

            float scaleX = slotScale.x / prefabScale.x;
            float scaleY = slotScale.y / prefabScale.y;
            float scaleZ = slotScale.z / prefabScale.z;


            float minScale = Mathf.Min(scaleX, scaleY, scaleZ);

            Vector3 scaled = instantiation.transform.localScale * minScale;
            instantiation.transform.localScale = scaled;
            
        }


    }
}
