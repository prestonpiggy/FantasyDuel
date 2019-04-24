using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    GameObject characterPanel;
    GameObject inventoryPanel;
    GameObject mainpanel;
    ItemDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    public GameObject weaponslot;
    public GameObject weaponslot2;
    public GameObject helmetslot;
    public GameObject shoulderslot;
    public GameObject chestslot;
    public GameObject glovesslot;
    public GameObject bootsslot;
    public GameObject deleteslot;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();

        slotAmount = 25;
        mainpanel = GameObject.Find("character_panel");
        characterPanel = GameObject.Find("inventory_panel");
        inventoryPanel = characterPanel.transform.FindChild("tmp").gameObject;
        mainpanel.SetActive(false);
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(inventoryPanel.transform);
            slots[i].GetComponent<RectTransform>().localScale = Vector3.one;
        }
        items.Add(new Item());
        items.Add(new Item());
        items.Add(new Item());
        items.Add(new Item());
        items.Add(new Item());
        items.Add(new Item());
        items.Add(new Item()); //x7
        items.Add(new Item());

        slots.Add(weaponslot);
        slots.Add(weaponslot2);
        slots.Add(helmetslot);
        slots.Add(shoulderslot);
        slots.Add(chestslot);
        slots.Add(glovesslot);
        slots.Add(bootsslot);//x7
        slots.Add(deleteslot);//x7


        slots[25].GetComponent<Slot>().id = 25;
        slots[26].GetComponent<Slot>().id = 26;
        slots[27].GetComponent<Slot>().id = 27;
        slots[28].GetComponent<Slot>().id = 28;
        slots[29].GetComponent<Slot>().id = 29;
        slots[30].GetComponent<Slot>().id = 30;
        slots[31].GetComponent<Slot>().id = 31;
        slots[32].GetComponent<Slot>().id = 32;

        slots[25].tag = "weapon";
        slots[26].tag = "weapon";



        //AddItem(0);
        //AddItem(1);
        //AddItem(0);
        //AddItem(1);
        //AddItem(1);
        //AddItem(1);
        //AddItem(1);
        //RemoveItem(1);
        //AddItem(2);

    }
    // fucntion preferably for creating new/excisting items on the run
    public void AddItem(int id)
    {

        Debug.Log(id);
        Item itemtoAdd = database.getItembyId(id);

        if (itemtoAdd.Stackable && CkifIteminInventory(itemtoAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();

                    //set the amount of the item to playerprefs too.
                    string name= (itemtoAdd.ID).ToString();
                    int amount = PlayerPrefs.GetInt(name + "amount",0);
                    amount++;
                    PlayerPrefs.SetInt(name+"amount", amount);
                    break;
                }

            }

        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemtoAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemtoAdd;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.transform.position = Vector2.zero;
                    itemObj.GetComponent<Image>().sprite = itemtoAdd.Sprite;
                    itemObj.GetComponent<RectTransform>().localScale = Vector3.one;
                    itemObj.name = itemtoAdd.Title;

                    break;
                }
            }
        }


    }
    //function when loading inventory 1st time, difference is specific place "int slot"
    public void AddItem(int id, int slot)
    {

        Debug.Log(id);
        Item itemtoAdd = database.getItembyId(id);

        if (itemtoAdd.Stackable && CkifIteminInventory(itemtoAdd))
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    //data.amount++;
                    //data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    string classname = CharacterScript.ClassName;
                    PlayerPrefs.SetInt(classname+"Slot"+slot,-1);
                    break;
                    
                }

            }



        }
        else
        {
            
            if (items[slot].ID == -1)
            {
                items[slot] = itemtoAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = itemtoAdd;
                itemObj.GetComponent<ItemData>().slot = slot;
                itemObj.transform.SetParent(slots[slot].transform);
                itemObj.transform.position = new Vector2(0, 0) ;
                itemObj.GetComponent<Image>().sprite = itemtoAdd.Sprite;
                itemObj.GetComponent<RectTransform>().localScale = Vector3.one;
                itemObj.name = itemtoAdd.Title;
                if (slot >= 25)
                {
                    itemObj.GetComponent<RectTransform>().position = slots[slot].GetComponent<RectTransform>().position;
                }

                
            }
        }


    }
    bool CkifIteminInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i].ID == item.ID)
                return true;
        return false;
    }
    public void RemoveItem(int id)
    {
        Debug.Log("remove method");
        Item itemToRemove = database.getItembyId(id);
        if (itemToRemove.Stackable && CkifIteminInventory(itemToRemove)) {
            for (int j = 0; j < items.Count; j++) {
                if (items[j].ID == id) { ItemData data = slots[j].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount--; data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    if (data.amount == 0) { Destroy(slots[j].transform.GetChild(0).gameObject);
                        items[j] = new Item(); break;
                    } if (data.amount == 1) {
                        slots[j].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = ""; break;
                    } break;
                }
            }
        }
        else for (int i = 0; i < items.Count; i++)
                if (items[i].ID != -1 && items[i].ID == id)
                {
                    Destroy(slots[i].transform.GetChild(0).gameObject);
                    items[i] = new Item();
                    break;
                }
    }
    public void addAmount(int i)
    {
        ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
        data.amount++;
        data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
        Debug.Log("++");
    }

    public void delAmount(GameObject item, int numbertoDelete, int itemID)
    {
        ItemData data = item.GetComponent<ItemData>();
        data.amount = data.amount - numbertoDelete;
        data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
        PlayerPrefs.SetInt(itemID + "amount", (data.amount));
        if (data.amount <= 0)
        {
            Destroy(item);
            PlayerPrefs.SetInt(itemID + "amount", (0));
        }


    }
    public void updates(string slot, Item item)
    {
        if ((slot =="weapon" || slot == "head" || slot == "shoulder" 
         || slot == "chest" || slot == "hands" || slot == "feet") && item.ID != -1)
        {
            CharacterScript.Attack += item.Attack;
            CharacterScript.Vitality += item.Vitality;
            CharacterScript.Defence += item.Defence;

            Debug.Log("itemin jälkeen: " + CharacterScript.Attack+ ", "+ CharacterScript.Vitality + ", " + CharacterScript.Defence) ;

        }else
        {
            CharacterScript.Attack -= item.Attack;
            CharacterScript.Vitality -= item.Vitality;
            CharacterScript.Defence -= item.Defence;
            Debug.Log("miinus att");
        }
    }


}
