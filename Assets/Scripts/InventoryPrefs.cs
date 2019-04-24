using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPrefs : MonoBehaviour {

    //warrior Prefs
    int inventoryslot;
    public Inventory inv;
    string classname;
    Item item;
    ItemDatabase database;



    // Use this for initialization
    void Start ()
    {
        database = GetComponent<ItemDatabase>();
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("2amount", 3);
        PlayerPrefs.SetInt("WarriorSlot20", 8);
        PlayerPrefs.SetInt("8amount", 20);
        PlayerPrefs.SetInt("WarriorSlot6", 1);
        PlayerPrefs.SetInt("WarriorSlot8", 2);
        PlayerPrefs.SetInt("WarriorSlot11", 0);
        PlayerPrefs.SetInt("WarriorSlot3", 3);
        PlayerPrefs.SetInt("WarriorSlot4", 4);
        PlayerPrefs.SetInt("WarriorSlot13", 5);
        PlayerPrefs.SetInt("WarriorSlot14", 6);
        PlayerPrefs.SetInt("WarriorSlot15", 7);
        classname = CharacterScript.ClassName;

        for (int i = 0; i <= 31; i++)
        {
            string Class= classname + "Slot" + i;
            Debug.Log(Class);
            inventoryslot = PlayerPrefs.GetInt(Class, -1);

            if (inventoryslot != -1)
            {
                
                Debug.Log(inventoryslot);
                item = database.getItembyId(inventoryslot);
                if (item.Stackable)
                {
                    string name = (item.ID).ToString();
                    
                    int amount = PlayerPrefs.GetInt(name+"amount",1);
                    inv.AddItem(inventoryslot, i);
                    for (int a = 1; a < amount; a++)
                    {
                        Debug.Log("stack");
                        inv.addAmount(i);
                        
                    }
                }
                else
                {
                    inv.AddItem(inventoryslot, i);
                }
            }
            //else if(i>24 && inventoryslot != -1)
            //{
            //    inv.AddItem(inventoryslot,i);
            //}
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void changeitem(int slotNumberFrom, int itemIDFrom,int slotNumberTo,int itemIDTo)
    {
        Debug.Log(slotNumberFrom + ", " +itemIDFrom + ", " + slotNumberTo + ", " + itemIDTo);
        string classname = CharacterScript.ClassName;
        string string1= classname + "Slot" + slotNumberFrom;
        string string2 = classname + "Slot" + slotNumberTo;
        Debug.Log(string1 + ", :" + string2);
        PlayerPrefs.SetInt(string1, itemIDTo);
        PlayerPrefs.SetInt(string2, itemIDFrom);

    }
}
