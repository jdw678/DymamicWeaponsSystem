using UnityEngine;
using System.Collections.Generic;

namespace DynamicWeaponsSystem
{

    [System.Serializable]
    public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
    {
        [SerializeField]
        public List<SerializablePair<TKey, TValue>> keyValuePairs = new List<SerializablePair<TKey, TValue>>();

        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        // Use this dictionary in your code
        public Dictionary<TKey, TValue> Dictionary => dictionary;


        public void AddOrOverwrite(TKey key, TValue value)
        {
            if (Dictionary.ContainsKey(key)) dictionary[key] = value;
            else Dictionary.Add(key, value);
        }

        // Save the dictionary content to the lists
        public void OnBeforeSerialize()
        {
            keyValuePairs.Clear();
            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                keyValuePairs.Add(new SerializablePair<TKey, TValue>(pair.Key, pair.Value));
            }
        }

        // Load the dictionary from the lists
        public void OnAfterDeserialize()
        {
            dictionary.Clear();
            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                // Handle potential duplicate keys or null values if necessary
                if (!dictionary.ContainsKey(keyValuePairs[i].Item1))
                {
                    dictionary.Add(keyValuePairs[i].Item1, keyValuePairs[i].Item2);
                }
            }
        }
    }
}
