using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour
{

    private List<Item> database = new List<Item>();
    private JsonData itemData;


    void Start()
    {


        TextAsset file = Resources.Load("items") as TextAsset;
        //string content = file.ToString();

        itemData = JsonMapper.ToObject(file.ToString());


        //Item item = new Item(0, "Ball", 5);
        //database.Add(item);
        //itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();

    }

    public Item getItembyId(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
                return database[i];
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"], itemData[i]["type"].ToString()
                , (int)itemData[i]["stats"]["attack"], (int)itemData[i]["stats"]["vitality"], (int)itemData[i]["stats"]["defence"], itemData[i]["description"].ToString(), (bool)itemData[i]["stackable"], itemData[i]["rarity"].ToString(), itemData[i]["slug"].ToString()
                ));
        }

    }
}


public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public string Type { get; set; }
    public int Attack { get; set; }
    public int Vitality { get; set; }
    public int Defence { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public string Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, int value,string type, int attack, int vitality,int defence, string description, bool stackable, string rarity, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Type = type;
        this.Attack = attack;
        this.Vitality = vitality;
        this.Defence = defence;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Graphics/Equipment/" + slug);
    }

    public Item()
    {

        this.ID = -1;
    }
}

