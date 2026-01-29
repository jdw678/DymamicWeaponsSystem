using DynamicWeaponsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DynamicWeaponsSystem
{
    public class StretchSlot : MonoBehaviour, ISlotter<ExampleWeaponPositionEnum>
    {
        [SerializeField]
        ExampleWeaponPositionEnum slot;
        [SerializeField]
        GameObject prefab;
        [SerializeField]
        GameObject instantiation;
        [SerializeField]
        Vector3 slotBounds, prefabBounds;
        public StretchSlot(ExampleWeaponPositionEnum slot)
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
            instantiation.transform.localScale = Vector3.one;

        }


    }
}
