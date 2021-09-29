using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;


    public void OnTriggerEnter(Collider other)
    {
        
        var item = other.GetComponent<TestItem>();
        if (item)
        {
            Debug.Log("Adding item" + item);
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Saving");
            inventory.Save();
        }if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Loading");
            inventory.Load();
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
