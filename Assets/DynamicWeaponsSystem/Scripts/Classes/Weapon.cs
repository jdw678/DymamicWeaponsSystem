using DynamicWeaponsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace DynamicWeaponsSystem
{
    [ExecuteAlways]
    public class Weapon : MonoBehaviour, IWeapon<ExampleStats>
    {

        [SerializeField]
        bool shooting;


        List<IAttatchable<ExampleStats>> attachables = new List<IAttatchable<ExampleStats>>();
        public List<GameObject> attachableObjs = new List<GameObject>();

        public ExampleStats baseStats = new ExampleStats(fireRate: 10, damage: 15, maxAmmo: 10);
        public ExampleStats cummulativeStats = new ExampleStats(fireRate: 10, damage: 15, maxAmmo: 10);

        public IShooter<ExampleStats> shooter;

        float fireTime = 9999;

        public WeaponPrefabHandler weaponPrefabHandler;

        bool reAttatch;

        private void Update()
        {
            CheckWeaponPrefabHandler();

            if (reAttatch)
            {
                List<IAttatchable<ExampleStats>> oldAttatchables = attachables;
                attachables = new List<IAttatchable<ExampleStats>>();
                foreach (var att in oldAttatchables)
                {
                    att.Attach(this);
                    Attatch(att);
                }
                reAttatch = false;
            }

            RecalculateStats();
            PerformActions();

            if (!Application.isPlaying)
                return;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                shooting = true;

                //for fire rate
                fireTime += Time.deltaTime;

                //fire rate check
                if (fireTime > 10f / cummulativeStats.fireRate)
                {
                    shooter.Shoot(cummulativeStats, transform.rotation);
                    fireTime = 0f;

                }
                    
            }
            else
            {
                shooting = false;
                fireTime = 9999;

            }
        }


        void CheckWeaponPrefabHandler()
        {


            if (this.weaponPrefabHandler != null)
                return;
            WeaponPrefabHandler weaponPrefabHandler = gameObject.GetComponentInChildren<WeaponPrefabHandler>();
            if (weaponPrefabHandler != null)
                return;

            weaponPrefabHandler = new GameObject("WeaponPrefabHandler").AddComponent<WeaponPrefabHandler>();
            weaponPrefabHandler.transform.parent = transform;
            this.weaponPrefabHandler = weaponPrefabHandler;
        }

        bool IWeapon<ExampleStats>.IsShooting()
        {
            return shooting;
        }

        void RecalculateStats()
        {
            cummulativeStats = new ExampleStats();
            cummulativeStats.AddStats(baseStats);
            foreach (IAttatchable<ExampleStats> att in attachables)
            {
                //basically sum all of the stats for each attachable
                att.ApplyStats(cummulativeStats);
            }
            
        }

        void PerformActions()
        {
            foreach(IAttatchable<ExampleStats> att in attachables)
            {
                att.PerformActions();
            }
        }

        public void Attatch(IAttatchable<ExampleStats> attachable)
        {
            attachables.Add(attachable);
            if (attachable is IPrefabDisplayable<ExampleWeaponPositionEnum>)
            {
                IPrefabDisplayable<ExampleWeaponPositionEnum> displayable = (IPrefabDisplayable<ExampleWeaponPositionEnum>)attachable;
                GameObject prefab = displayable.GetPrefab();
                weaponPrefabHandler.FindChildren();
                weaponPrefabHandler.DisplayPrefab(prefab, displayable.GetSlot());

            }
        }

        public IStattable<ExampleStats> GetStats()
        {
            return cummulativeStats;
        }
        
        public void SetStats(IStattable<ExampleStats> stats)
        {
            this.cummulativeStats = (ExampleStats)stats;
        }

        public void SetShooter(IShooter<ExampleStats> shooter)
        {
            this.shooter = shooter;
        }

        public IShooter<ExampleStats> GetShooter()
        {
            return shooter;
        }

        private void OnValidate()
        {
            List<GameObject> newAttatchablObjsList = new List<GameObject>();
            attachables = new List<IAttatchable<ExampleStats>>();
            foreach (GameObject obj in attachableObjs)
            {
                if (obj == null)
                    continue;

                IAttatchable<ExampleStats> att = obj.GetComponent<IAttatchable<ExampleStats>>();

                if (att == null)
                    continue;

                bool exists = newAttatchablObjsList.Exists(x => x.Equals(obj));

                if (newAttatchablObjsList.Exists(x => x.Equals(obj)))
                    continue;

                newAttatchablObjsList.Add(obj);
                attachables.Add(att);
            }

            attachableObjs = newAttatchablObjsList;

            reAttatch = true;

        }

        
    }

    [CustomEditor(typeof(Weapon)), CanEditMultipleObjects]
    public class WeaponEditor : Editor
    {
        Weapon obj;
        public void OnEnable()
        {
            obj = (Weapon)target;
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.ObjectField((UnityEngine.Object)obj.GetShooter(), typeof(IShooter<ExampleStats>), true);
            EditorGUILayout.EndHorizontal();
            base.OnInspectorGUI();
        }
    }
}
