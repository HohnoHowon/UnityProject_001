using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class SerializableDictionary<TKey,TVaule> : Dictionary<TKey,TVaule>, ISerializationCallbackReceiver
{
    public List<TKey> inspectorKeys;
    public List<TVaule> inspectorValues;

    public SerializableDictionary()
    {
        inspectorKeys = new List<TKey>();
        inspectorValues = new List<TVaule>();
        SyncInspectorFromDictionary();
    }

    public new void Add(TKey key, TVaule value)
    {
        base.Add(key, value);
        SyncInspectorFromDictionary();
    }

    public new void Remove(TKey key)
    {
        base.Remove(key);
        SyncInspectorFromDictionary();
    }

    public void OnBeforeSerialized() {}
    public void SyncInspectorFromDictionary()
    {
        inspectorKeys.Clear();
        inspectorValues.Clear();

        foreach(KeyValuePair<TKey, TVaule> pair in this)
        {
            inspectorKeys.Add(pair.Key);
            inspectorValues.Add(pair.Value);
        }
    }

    public void SyncDictionaryFromInspector()
    {
        foreach (var key in Keys.ToList())
        {
            base.Remove(key);
        }

        for (int i = 0; i < inspectorKeys.Count; i++)
        {
            if (this.ContainsKey(inspectorKeys[i]))
            {
                Debug.LogError("중복 키가 있습니다.");
                break;
            }
            base.Add(inspectorKeys[i], inspectorValues[i]);
        }
    }

    public void OnAfterDeserialize()
    {
        if (inspectorKeys.Count == inspectorValues.Count)
        {
            SyncDictionaryFromInspector();
        }
    }

}
