using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Debug.Log(" Item Item IDBO: " + Items);
            Items[i].Id = i;
            Debug.Log("Items ID = (this would be i) = " + i);
            Debug.Log("IDBO Trig");
            GetItem.Add(i, Items[i]);
            Debug.Log("IDBO Trig 2");
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObject>();
    }
}
