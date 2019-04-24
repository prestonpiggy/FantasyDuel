using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeletePanel : MonoBehaviour
{
    public Button plusButton;
    public Button minusButton;
    public Button confirmButton;
    public Text numbertext;
    int startingnumber = 1;
    private GameObject deletepanel;
    private Inventory inv;
    GameObject itemToDelete;
    int itemid;

    // Use this for initialization
    void Start()
    {
        inv = GameObject.Find("inventory_controller").GetComponent<Inventory>();
        deletepanel = GameObject.Find("deletepanel");
        deletepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        numbertext.text = startingnumber.ToString();
    }
    public void addOnClick()
    {
        startingnumber++;
    }
    public void delOnClick()
    {
        if (startingnumber > 0)
        {
            startingnumber--;
        }
    }
    public void ok()
    {
        deletepanel.SetActive(false);
        inv.delAmount(itemToDelete, startingnumber, itemid);
        startingnumber = 1;
    }
    public void Active(int id)
    {

        itemid = id;
        deletepanel.SetActive(true);

    }
    public void setObject(GameObject item)
    {
        itemToDelete = item;
    }

}

