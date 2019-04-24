using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler, IEndDragHandler
{
    public int id;
    private Inventory inv;
    DeletePanel deletePanel;




    void Start()
    {
        inv = GameObject.Find("inventory_controller").GetComponent<Inventory>();
        deletePanel = inv.GetComponent<DeletePanel>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        Debug.Log(inv.slots[id].tag);
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (inv.slots[id].tag == "delete")
        {
            if (droppedItem.item.Stackable == false)
            {
                Debug.Log("delete drop no stack");
                InventoryPrefs.changeitem(droppedItem.slot, droppedItem.item.ID, inv.slots[id].GetComponent<Slot>().id, inv.items[id].ID);
                inv.items[droppedItem.slot] = new Item();
                inv.items[id] = droppedItem.item;
                droppedItem.slot = id;
                Destroy(droppedObject);
                inv.items[32] = new Item();
            }
            else
            {
                Debug.Log("delete drop stacking");

                int count = PlayerPrefs.GetInt(droppedItem.item.ID + "amount", 1);
                Debug.Log(count);

                if (count == 1)
                {
                    InventoryPrefs.changeitem(droppedItem.slot, droppedItem.item.ID, inv.slots[id].GetComponent<Slot>().id, inv.items[id].ID);
                    PlayerPrefs.SetInt(droppedItem.item.ID + "amount", count - 1);
                    inv.items[droppedItem.slot] = new Item();
                    inv.items[id] = droppedItem.item;
                    droppedItem.slot = id;
                    Destroy(droppedObject);
                    inv.items[32] = new Item();
                }
                else
                {
                    deletePanel.Active(droppedItem.item.ID);
                    deletePanel.setObject(droppedObject);
                    inv.items[id] = droppedItem.item;

                }
            }


        }
        else if (inv.slots[id].tag == droppedItem.item.Type && inv.items[id].ID == -1
         || inv.slots[id].tag == "Untagged" && droppedItem.slot >= 25)// && inv.items[id].ID == -1)
        {
            InventoryPrefs.changeitem(droppedItem.slot, droppedItem.item.ID, inv.slots[id].GetComponent<Slot>().id, inv.items[id].ID);
            Debug.Log("special drop");
            inv.items[droppedItem.slot] = new Item();
            inv.items[id] = droppedItem.item;
            droppedItem.slot = id;
            inv.updates(inv.slots[id].tag, droppedItem.item);

        }
        else if (inv.items[id].ID == -1 && inv.slots[id].tag == "Untagged")
        {
            InventoryPrefs.changeitem(droppedItem.slot, droppedItem.item.ID, inv.slots[id].GetComponent<Slot>().id, inv.items[id].ID);
            Debug.Log("drop on empty");
            inv.items[droppedItem.slot] = new Item();
            inv.items[id] = droppedItem.item;
            droppedItem.slot = id;

        }
        else if (droppedItem.slot != id && inv.slots[id].tag == "Untagged")
        {
            InventoryPrefs.changeitem(droppedItem.slot, droppedItem.item.ID, inv.slots[id].GetComponent<Slot>().id, inv.items[id].ID);
            Debug.Log("switch items");
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slot = droppedItem.slot;
            item.transform.SetParent(inv.slots[droppedItem.slot].transform);
            item.transform.position = inv.slots[droppedItem.slot].transform.position;

            droppedItem.slot = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
            inv.items[id] = droppedItem.item;
        }




    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("eventData.point");
    }
}

