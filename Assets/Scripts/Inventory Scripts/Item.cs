using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;

    [HideInInspector]
    public bool equipped;
    public bool playersWeapon;

    [HideInInspector]
    public GameObject weapon;
    [HideInInspector]
    public GameObject weaponManager;

    public void Start()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager");
        if (!playersWeapon)
        {
            int allWeapons = weaponManager.transform.childCount;
            for (int i = 0; i < allWeapons; i++)
            {
                if(weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
                    print(weapon.name);
                }
            }
        }
    }

    public void Update()
    {
        if (equipped)
        {
            // does what weapons do

            if (Input.GetKeyDown(KeyCode.G))
                equipped = false;

            if (equipped == false)
                this.gameObject.SetActive(false);
        }
    }

    public void ItemUsage()
    {
        Debug.Log("Item Usage Activate");
        //weapon/health/whatever
        if(type == "Weapon")
        {
            Debug.Log("Weapon is Active");
            weapon.SetActive(true);
            weapon.GetComponent<Item>().equipped = true;
        }

    }
}


