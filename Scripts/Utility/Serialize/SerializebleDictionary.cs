using System.Collections.Generic;
using UnityEngine;

namespace Utility.Serialize
{
    [System.Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField] private List<SerializableKeyValuePair<TKey, TValue>> data = new();

        public void OnBeforeSerialize()
        {
            data.Clear();
            using var e = GetEnumerator();
            while (e.MoveNext())
            {
                data.Add(new SerializableKeyValuePair<TKey, TValue>(e.Current.Key, e.Current.Value));
            }
        }

        public void OnAfterDeserialize()
        {
            Clear();
            foreach (var pair in data)
            {
                this[pair.Key] = pair.Value;
            }
        }
    }

    [System.Serializable]
    public class SerializableKeyValuePair<TKey, TValue>
    {
        [SerializeField] public TKey Key;
        [SerializeField] public TValue Value;

        public SerializableKeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}

